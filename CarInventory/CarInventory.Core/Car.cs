namespace CarInventory.Core
{
    public class Car
    {
        /// <summary>
        /// Get and Set Property of Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Get and Set Property of Brand
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// Get and Set Property of Model
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Get and Set Property of Year
        /// </summary>
        public int? Year { get; set; }
        /// <summary>
        /// Get and Set Property of Price
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// Get and Set Property of New
        /// </summary>
        public bool? New { get; set; }
    }
}
