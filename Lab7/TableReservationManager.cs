using System;
using System.Collections.Generic;
using System.Linq;

public class TableReservationManager
{
    public List<Restaurant> Restaurants { get; private set; }

    public TableReservationManager()
    {
        Restaurants = new List<Restaurant>();
    }

    public void AddRestaurant(string name, int tableCount)
    {
        Restaurant restaurant = new Restaurant(name, tableCount);
        Restaurants.Add(restaurant);
    }

    public List<string> FindAllFreeTables(DateTime date)
    {
        return Restaurants
            .SelectMany(restaurant => restaurant.GetAvailableTables(date))
            .ToList();
    }

    public bool BookTable(string restaurantName, DateTime date, int tableNumber)
    {
        try
        {
            var restaurant = Restaurants.FirstOrDefault(r => r.Name == restaurantName);

            if (restaurant != null)
            {
                return restaurant.BookTable(date, tableNumber);
            }

            throw new InvalidOperationException("Restaurant not found");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error booking table: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            return false;
        }
    }

    public void SortRestaurantsByAvailability(DateTime date)
    {
        Restaurants = Restaurants
            .OrderByDescending(restaurant => restaurant.CountAvailableTables(date))
            .ToList();
    }
}
