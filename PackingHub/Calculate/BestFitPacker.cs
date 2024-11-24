namespace PackingHub.Calculate
{
    /// <summary>
    /// Класс, реализующий алгоритм укладки грузов в контейнер с учётом их особенностей и ориентаций.
    /// </summary>
    public static class BestFitPacker
    {
        /// <summary>
        /// Глобальное свойство для переменной step.
        /// </summary>
        public static float Step
        {
            get => step;
            set
            {
                if (value < 0f) throw new ArgumentOutOfRangeException("Значение step отрицательное!");
                step = value;
            }
        }
        /// <summary>
        /// Глобальная переменная для задания точности шагов поиска позиции для укладки грузов.
        /// </summary>
        private static float step = -1;

        /// <summary>
        /// Укладывает грузы в контейнер, учитывая особенности манипуляции (например, хрупкость, химическую активность, воспламеняемость).
        /// Попытается сначала выполнить укладку с разделением особых грузов, а затем — без учёта таких требований.
        /// </summary>
        /// <param name="container">Контейнер, в который необходимо уложить грузы.</param>
        /// <param name="cargos">Список грузов для укладки.</param>
        /// <returns>
        /// Контейнер с уложенными грузами. Если невозможно уложить все грузы, возвращает контейнер с максимально возможным количеством размещённых грузов.
        /// </returns>
        /// <exception cref="InvalidOperationException">Бросается, если глобальная переменная Step не задана.</exception>
        public static ContainerToCalc Pack(ContainerToCalc container, List<CargoToCalc> cargos)
        {
            List<CargoToCalc> specialCargos = cargos.Where(c => c.ChemicallyActive || c.Flammable).ToList();
            List<CargoToCalc> regularCargos = cargos.Where(c => !c.ChemicallyActive && !c.Flammable).ToList();

            ContainerToCalc containerWithSpecialHandling = PackWithSpecialHandling(container, specialCargos, regularCargos);

            if (containerWithSpecialHandling == null || containerWithSpecialHandling.GetPackedCargos.Count != cargos.Count)
            {
                return PackWithoutSpecialHandling(container, cargos);
            }

            return containerWithSpecialHandling;
        }

        /// <summary>
        /// Выполняет укладку грузов в контейнер с разделением особых грузов (например, химически активных или воспламеняемых) от остальных.
        /// </summary>
        /// <param name="container">Контейнер, в который осуществляется укладка.</param>
        /// <param name="specialCargos">Список грузов с особыми признаками.</param>
        /// <param name="regularCargos">Список обычных грузов.</param>
        /// <returns>
        /// Контейнер с уложенными грузами или null, если укладка невозможна.
        /// </returns>
        private static ContainerToCalc PackWithSpecialHandling(ContainerToCalc container, List<CargoToCalc> specialCargos, List<CargoToCalc> regularCargos)
        {
            ContainerToCalc tempContainer = new ContainerToCalc(container.Length, container.Width, container.Height, container.WallThickness, container.Weight);
            List<CargoToCalc> packedCargos = new List<CargoToCalc>();

            foreach (var specialCargo in specialCargos)
            {
                bool placed = false;
                foreach (var (length, width, height) in specialCargo.GetOrientations())
                {
                    var orientedCargo = new CargoToCalc(length, width, height, specialCargo.Weight) { Name = specialCargo.Name };

                    Vector3 bestPosition = FindBestPositionWithSpecialHandling(tempContainer, orientedCargo, packedCargos);
                    if (bestPosition != null)
                    {
                        tempContainer.AddCargo(orientedCargo, bestPosition);
                        packedCargos.Add(orientedCargo);
                        placed = true;
                        break;
                    }
                }

                if (!placed)
                {
                    return null;
                }

                if (regularCargos.Count > 0)
                {
                    var regularCargo = regularCargos[0];
                    placed = false;
                    foreach (var (length, width, height) in regularCargo.GetOrientations())
                    {
                        var orientedCargo = new CargoToCalc(length, width, height, regularCargo.Weight) { Name = regularCargo.Name };

                        Vector3 bestPosition = FindBestPosition(tempContainer, orientedCargo);
                        if (bestPosition != null)
                        {
                            tempContainer.AddCargo(orientedCargo, bestPosition);
                            packedCargos.Add(orientedCargo);
                            regularCargos.RemoveAt(0);
                            placed = true;
                            break;
                        }
                    }
                }
            }

            foreach (var regularCargo in regularCargos)
            {
                bool placed = false;
                foreach (var (length, width, height) in regularCargo.GetOrientations())
                {
                    var orientedCargo = new CargoToCalc(length, width, height, regularCargo.Weight) { Name = regularCargo.Name };

                    Vector3 bestPosition = FindBestPosition(tempContainer, orientedCargo);
                    if (bestPosition != null)
                    {
                        tempContainer.AddCargo(orientedCargo, bestPosition);
                        packedCargos.Add(orientedCargo);
                        placed = true;
                        break;
                    }
                }

                if (!placed)
                {
                    return null;
                }
            }

            return tempContainer;
        }

        /// <summary>
        /// Выполняет укладку грузов в контейнер без учёта особенностей (хрупкость, химическая активность и т.д.).
        /// </summary>
        /// <param name="container">Контейнер, в который осуществляется укладка.</param>
        /// <param name="cargos">Список всех грузов.</param>
        /// <returns>
        /// Контейнер с уложенными грузами.
        /// </returns>
        private static ContainerToCalc PackWithoutSpecialHandling(ContainerToCalc container, List<CargoToCalc> cargos)
        {
            var sortedCargos = SortCargos(cargos);

            foreach (var cargo in sortedCargos)
            {
                bool placed = false;
                foreach (var (length, width, height) in cargo.GetOrientations())
                {
                    var orientedCargo = new CargoToCalc(length, width, height, cargo.Weight) { Name = cargo.Name };

                    Vector3 bestPosition = FindBestPosition(container, orientedCargo);
                    if (bestPosition != null)
                    {
                        container.AddCargo(orientedCargo, bestPosition);
                        placed = true;
                        break;
                    }
                }
            }

            return container;
        }

        /// <summary>
        /// Находит оптимальную позицию для размещения груза в контейнере с учётом особых требований:
        /// грузы, отмеченные как химически активные или воспламеняемые, не должны находиться рядом.
        /// </summary>
        /// <param name="container">Контейнер, в котором осуществляется поиск позиции.</param>
        /// <param name="cargo">Груз, для которого ищется позиция.</param>
        /// <param name="packedCargos">Список уже размещённых грузов в контейнере.</param>
        /// <returns>
        /// Оптимальная позиция для груза в контейнере в виде объекта <see cref="Vector3"/> 
        /// или null, если подходящая позиция не найдена.
        /// </returns>
        /// <exception cref="InvalidOperationException">Бросается, если глобальная переменная Step не задана.</exception>
        public static Vector3 FindBestPositionWithSpecialHandling(ContainerToCalc container, CargoToCalc cargo, List<CargoToCalc> packedCargos)
        {
            if (step == -1) throw new InvalidOperationException("Переменной step не назначено значение!");
            Vector3 bestPosition = null;
            float minRemainingVolume = float.MaxValue;

            for (float z = 0; z < container.InnerHeight; z = MathF.Round(z + step, 2))
            {
                for (float y = 0; y < container.InnerWidth; y = MathF.Round(y + step, 2))
                {
                    for (float x = 0; x < container.InnerLength; x = MathF.Round(x + step, 2))
                    {
                        Vector3 position = new Vector3(x, y, z);
                        if (container.AddCargo(cargo, position))
                        {
                            bool hasSpecialNeighbor = false;
                            foreach (var packed in packedCargos)
                            {
                                if ((packed.ChemicallyActive || packed.Flammable) &&
                                    container.BoxesOverlap(cargo, position, packed, FindPosition(container, packed)))
                                {
                                    hasSpecialNeighbor = true;
                                    break;
                                }
                            }

                            if (!hasSpecialNeighbor)
                            {
                                float remainingVolume = CalculateRemainingVolume(container);
                                container.GetPackedCargos.RemoveAt(container.GetPackedCargos.Count - 1);

                                if (remainingVolume < minRemainingVolume)
                                {
                                    minRemainingVolume = remainingVolume;
                                    bestPosition = position;
                                }
                            }
                            else
                            {
                                container.GetPackedCargos.RemoveAt(container.GetPackedCargos.Count - 1);
                            }
                        }
                    }
                }
            }

            return bestPosition;
        }

        /// <summary>
        /// Находит оптимальную позицию для размещения груза в контейнере без учёта особых требований.
        /// </summary>
        /// <param name="container">Контейнер, в котором осуществляется поиск позиции.</param>
        /// <param name="cargo">Груз, для которого ищется позиция.</param>
        /// <returns>
        /// Оптимальная позиция для груза в контейнере в виде объекта <see cref="Vector3"/> 
        /// или null, если подходящая позиция не найдена.
        /// </returns>
        /// <exception cref="InvalidOperationException">Бросается, если глобальная переменная Step не задана.</exception>
        public static Vector3 FindBestPosition(ContainerToCalc container, CargoToCalc cargo)
        {
            if (step == -1) throw new InvalidOperationException("Переменной step не назначено значение!");
            Vector3 bestPosition = null;
            float minRemainingVolume = float.MaxValue;

            for (float z = 0; z < container.InnerHeight; z = MathF.Round(z + step, 2))
            {
                for (float y = 0; y < container.InnerWidth; y = MathF.Round(y + step, 2))
                {
                    for (float x = 0; x < container.InnerLength; x = MathF.Round(x + step, 2))
                    {
                        Vector3 position = new Vector3(x, y, z);
                        if (container.AddCargo(cargo, position))
                        {
                            float remainingVolume = CalculateRemainingVolume(container);
                            container.GetPackedCargos.RemoveAt(container.GetPackedCargos.Count - 1);

                            if (remainingVolume < minRemainingVolume)
                            {
                                minRemainingVolume = remainingVolume;
                                bestPosition = position;
                            }
                        }
                    }
                }
            }
            return bestPosition;
        }

        /// <summary>
        /// Находит позицию конкретного груза, уже размещённого в контейнере.
        /// </summary>
        /// <param name="container">Контейнер, в котором размещён груз.</param>
        /// <param name="cargo">Груз, для которого необходимо найти позицию.</param>
        /// <returns>
        /// Позиция груза в контейнере в виде объекта <see cref="Vector3"/> или null, если груз не найден.
        /// </returns>
        private static Vector3 FindPosition(ContainerToCalc container, CargoToCalc cargo)
        {
            foreach (var packedCargo in container.GetPackedCargos)
            {
                if (packedCargo.Item1 == cargo)
                {
                    return packedCargo.Item2;
                }
            }
            return null;
        }

        /// <summary>
        /// Сортирует список грузов по следующим критериям: 
        /// сначала по объёму (убывание), затем по весу (убывание), затем по хрупкости (хрупкие грузы идут последними).
        /// </summary>
        /// <param name="cargos">Список грузов для сортировки.</param>
        /// <returns>
        /// Отсортированный список грузов.
        /// </returns>
        public static List<CargoToCalc> SortCargos(List<CargoToCalc> cargos)
        {
            return cargos
                .OrderByDescending(c => c.Length * c.Width * c.Height)
                .ThenByDescending(c => c.Weight)
                .ThenByDescending(c => !c.Fragility)
                .ToList();
        }

        /// <summary>
        /// Рассчитывает оставшийся свободный объём в контейнере после укладки грузов.
        /// </summary>
        /// <param name="container">Контейнер, для которого производится расчёт.</param>
        /// <returns>
        /// Объём оставшегося свободного пространства в контейнере.
        /// </returns>
        private static float CalculateRemainingVolume(ContainerToCalc container)
        {
            float usedVolume = 0;
            foreach (var packedCargo in container.GetPackedCargos)
            {
                usedVolume += packedCargo.Item1.Length * packedCargo.Item1.Width * packedCargo.Item1.Height;
            }
            return container.InnerLength * container.InnerWidth * container.InnerHeight - usedVolume;
        }
    }
}