namespace PackingHub.Calculate
{
    /// <summary>
    /// Представляет трёхмерный вектор с координатами X, Y и Z.
    /// </summary>
    public class Vector3
    {
        /// <summary>
        /// Координата X вектора.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Координата Y вектора.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Координата Z вектора.
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Vector3"/> с заданными координатами X, Y и Z.
        /// </summary>
        /// <param name="x">Координата X вектора.</param>
        /// <param name="y">Координата Y вектора.</param>
        /// <param name="z">Координата Z вектора.</param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

}