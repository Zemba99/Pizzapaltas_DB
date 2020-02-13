using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TypeLib;

namespace TypeLib
{
    public interface IRepository : IDisposable
    {
     
        Task<Beverage> AddBeverage(Beverage beverage);
        Task<Employee> AddEmployee(Employee employee);
        Task<Ingredient> AddIngredient(Ingredient ingredient);
        Task<Pasta> AddPasta(Pasta pasta);
        Task<PizzaRecipe> AddPizza(PizzaRecipe pizza);
        Task<Sallad> AddSallad(Sallad sallad);
        Task<Beverage> DeleteBeverage(Beverage beverage);
        Task<Employee> DeleteEmployee(Employee employee);
        Task<Ingredient> DeleteIngredient(Ingredient ingredient);
        Task<Pasta> DeletePasta(Pasta pasta);
        Task<PizzaRecipe> DeletePizza(PizzaRecipe pizza);
        Task<Sallad> DeleteSallad(Sallad sallad);
        Task<Beverage> EditBeverage(Beverage beverage);
        Task<Employee> EditEmployee(Employee employee);
        Task<Ingredient> EditIngredient(Ingredient ingredient);
        Task<Pasta> EditPasta(Pasta pasta);
        Task<PizzaRecipe> EditPizza(PizzaRecipe pizza);
        Task<Sallad> EditSallad(Sallad sallad);
        Task<IEnumerable<Beverage>> GetBeverages();
        Task<IEnumerable<Employee>> GetEmployees();
        Task<IEnumerable<Ingredient>> GetIngredients();
        Task<IEnumerable<Pasta>> GetPastas();
        Task<IEnumerable<PizzaRecipe>> GetPizzas();
        Task<IEnumerable<Sallad>> GetSallads();
        Task<IEnumerable<Order>> GetOrdersMakingtwo();
        Task<Order> DeleteOrders(Order Order);
        Task<IEnumerable<Order>> GetOrdersMaking();
        Task<Order> AddNewOrder(Order Order);
        Task<IEnumerable<Order>> GetOrders();
        Task<PizzaRecipe> AddNewPizzaContent(PizzaRecipe pizza);
        Task<IEnumerable<PizzaRecipe>> GetCurrentpizzas();
    }
}