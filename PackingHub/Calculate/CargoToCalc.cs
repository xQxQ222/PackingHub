using PackingHub.Models;

namespace PackingHub.Calculate
{
    public class CargoToCalc:Cargo
    {

        public CargoToCalc(Cargo cargo)
        {
            this.Fragility = cargo.Fragility;
            this.Number = cargo.Number;
            this.AdditionalEquipment = cargo.AdditionalEquipment;
            this.Flammable = cargo.Flammable;
            this.ChemicallyActive = cargo.ChemicallyActive;
            this.Status = cargo.Status;
            this.DeliveryAddress = cargo.DeliveryAddress;
            this.Customer=cargo.Customer;
            this.Supplier = cargo.Supplier;
            this.Weight = cargo.Weight;
            this.Height = cargo.Height;
            this.Width = cargo.Width;
            this.Length = cargo.Length;
            this.Name = cargo.Name;
        }
        public CargoToCalc(float length, float width, float height, float weight)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
        }

        /// <summary>
        /// Возвращает все возможные ориентации груза, представляя его в шести разных положениях.
        /// </summary>
        /// <returns>Список кортежей, содержащих длину, ширину и высоту для каждой ориентации.</returns>
        public IEnumerable<(float, float, float)> GetOrientations()
        {
            yield return (Length, Width, Height); // Оригинальная ориентация
            yield return (Length, Height, Width); // Поворот: длина остаётся, высота и ширина меняются местами
            yield return (Width, Length, Height); // Поворот: ширина становится длиной
            yield return (Width, Height, Length); // Поворот: ширина остаётся, длина и высота меняются местами
            yield return (Height, Length, Width); // Поворот: высота становится длиной
            yield return (Height, Width, Length); // Поворот: высота остаётся, длина и ширина меняются местами
        }
    }
}
