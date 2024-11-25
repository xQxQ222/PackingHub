using PackingHub.Models;

namespace PackingHub.Calculate
{
    public class ContainerToCalc:Container
    {
        public ContainerToCalc(Container container)
        {
            this.Number = container.Number;
            this.Width = container.Width;
            this.Height = container.Height;
            this.Length = container.Length;
            this.Weight = container.Weight;
            this.Status = container.Status;
            this.WallThickness = container.WallThickness/100;
            this.Name = container.Name;
        }
        public float InnerLength => Length - 2 * WallThickness;

        /// <summary>
        /// Внутренняя ширина контейнера (без учёта толщины стенок).
        /// </summary>
        public float InnerWidth => Width - 2 * WallThickness;

        /// <summary>
        /// Внутренняя высота контейнера (без учёта толщины стенок).
        /// </summary>
        public float InnerHeight => Height - 2 * WallThickness;

        /// <summary>
        /// Список упакованных грузов и их позиций в контейнере.
        /// </summary>
        private List<Tuple<Cargo, Vector3>> _packedCargos = new List<Tuple<Cargo, Vector3>>();

        /// <summary>
        /// Создаёт новый экземпляр класса <see cref="Container"/> с заданными размерами и характеристиками.
        /// </summary>
        /// <param name="length">Внешняя длина контейнера.</param>
        /// <param name="width">Внешняя ширина контейнера.</param>
        /// <param name="height">Внешняя высота контейнера.</param>
        /// <param name="wallThickness">Толщина стенок контейнера.</param>
        /// <param name="weight">Максимально допустимый вес контейнера.</param>
        public ContainerToCalc(float length, float width, float height, float wallThickness, float weight)
        {
            Length = length;
            Width = width;
            Height = height;
            WallThickness = wallThickness;
            Weight = weight;
        }

        /// <summary>
        /// Добавляет груз в контейнер в заданную позицию, если это возможно.
        /// </summary>
        /// <param name="cargo">Груз для размещения.</param>
        /// <param name="position">Позиция в контейнере, где должен быть размещён груз.</param>
        /// <returns>
        /// true, если груз успешно добавлен; false, если добавление невозможно 
        /// из-за пересечения с другими грузами или выхода за пределы контейнера.
        /// </returns>
        public bool AddCargo(Cargo cargo, Vector3 position)
        {
            if (position.X + cargo.Length <= InnerLength &&
                position.Y + cargo.Width <= InnerWidth &&
                position.Z + cargo.Height <= InnerHeight &&
                !IsOverlap(cargo, position))
            {
                _packedCargos.Add(Tuple.Create(cargo, position));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Проверяет, пересекается ли заданный груз с уже размещёнными в контейнере грузами.
        /// </summary>
        /// <param name="cargo">Груз для проверки.</param>
        /// <param name="position">Позиция предполагаемого размещения груза.</param>
        /// <returns>true, если пересечение есть; false, если пересечения нет.</returns>
        private bool IsOverlap(Cargo cargo, Vector3 position)
        {
            foreach (var packedCargo in _packedCargos)
            {
                if (BoxesOverlap(cargo, position, packedCargo.Item1, packedCargo.Item2))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Определяет, пересекаются ли два заданных груза.
        /// </summary>
        /// <param name="box1">Первый груз.</param>
        /// <param name="pos1">Позиция первого груза.</param>
        /// <param name="box2">Второй груз.</param>
        /// <param name="pos2">Позиция второго груза.</param>
        /// <returns>true, если грузы пересекаются; false, если грузы не пересекаются.</returns>
        public bool BoxesOverlap(Cargo box1, Vector3 pos1, Cargo box2, Vector3 pos2)
        {
            return
                pos1.X < pos2.X + box2.Length && pos1.X + box1.Length > pos2.X &&
                pos1.Y < pos2.Y + box2.Width && pos1.Y + box1.Width > pos2.Y &&
                pos1.Z < pos2.Z + box2.Height && pos1.Z + box1.Height > pos2.Z;
        }

        /// <summary>
        /// Возвращает список всех упакованных грузов и их позиций в контейнере.
        /// </summary>
        public List<Tuple<Cargo, Vector3>> GetPackedCargos => _packedCargos;
    }
}
