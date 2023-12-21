namespace ConsoleAppRestaurantTableReservationManager
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BookTable_SuccessfullyBooksTable_ReturnsTrue()
        {
            // Arrange
            TableReservationManager manager = new TableReservationManager();
            manager.AddRestaurant("A", 10);

            // Act
            bool result = manager.BookTable("A", new DateTime(2023, 12, 25), 3);

            // Assert
            NUnit.Framework.Assert.IsTrue(result);
        }
        [Test]
        public void BookTable_TableAlreadyBooked_ReturnsFalse()
        {
            // Arrange
            TableReservationManager manager = new TableReservationManager();
            manager.AddRestaurant("A", 10);

            // Act
            manager.BookTable("A", new DateTime(2023, 12, 25), 3);
            bool result = manager.BookTable("A", new DateTime(2023, 12, 25), 3);

            // Assert
            NUnit.Framework.Assert.IsFalse(result);
        }

        [Test]
        public void FindAllFreeTables_ReturnsAvailableTables()
        {
            // Arrange
            TableReservationManager manager = new TableReservationManager();
            manager.AddRestaurant("A", 10);
            manager.BookTable("A", new DateTime(2023, 12, 25), 3);

            // Act
            var freeTables = manager.FindAllFreeTables(new DateTime(2023, 12, 25));

            // Assert
            NUnit.Framework.Assert.AreEqual(9, freeTables.Count); // Only one table is booked, so 9 should be available
        }
    }
}