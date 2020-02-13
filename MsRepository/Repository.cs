using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TypeLib;
using Dapper;
using System.Linq;
using System.Collections.Generic;
using Npgsql;

namespace MsRepository
{

    public class Repository : IDisposable, IRepository
    {

        IDbConnection Connection { get; set; }

        public string ConnectionString { get; } = "Data Source = SQL6009.site4now.net; Initial Catalog = DB_A53DDD_topdog; User Id = DB_A53DDD_topdog_admin; Password=falling-2apple;MultipleActiveResultSets=True";

        public Repository()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        #region Employees
        public async Task<Employee> AddEmployee(Employee employee)
        {
            return (await Connection.QueryAsync<Employee>("AddEmployee", new { Username = employee.Username, employee.Password, employee.Role }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }
        public async Task<Employee> DeleteEmployee(Employee employee)
        {
            return (await Connection.QueryAsync<Employee>("DeleteEmployee", new { Username = employee.Username, Password = employee.Password, Role = employee.Role }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }
        public async Task<Employee> EditEmployee(Employee employee)
        {
            return (await Connection.QueryAsync<Employee>("EditEmployee", new { ID = employee.ID, Username = employee.Username, Password = employee.Password, Role = employee.Role }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return (await Connection.QueryAsync<Employee>("GetEmployees", null, commandType: CommandType.StoredProcedure));
        }
        #endregion

        #region Orders

        public async Task<IEnumerable<Order>> GetOrdersMaking()
        {
            return (await Connection.QueryAsync<Order>("GetOrdersMaking", null, commandType: CommandType.StoredProcedure));
        }
        public async Task<IEnumerable<Order>> GetOrdersMakingtwo()
        {
            return (await Connection.QueryAsync<Order>("GetOrdersMakingtwo", null, commandType: CommandType.StoredProcedure));
        }
        public async Task<Order> DeleteOrders(Order Order)
        {
            return (await Connection.QueryAsync<Order>("DeleteOrders", new { ID = Order.ID }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }
        public async Task<Order> AddNewOrder(Order Order)
        {
            return (await Connection.QueryAsync<Order>("AddNewOrder", new { Order_status = Order.Order_status}, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return (await Connection.QueryAsync<Order>("GetOrders", null, commandType: CommandType.StoredProcedure));
        }
        #endregion

        #region Pizzas
        public async Task<PizzaRecipe> AddNewPizzaContent(PizzaRecipe pizza)
        {
            return (await Connection.QueryAsync<PizzaRecipe>("AddNewPizzaContent", new { Ingredients_id = pizza.Ingredient_id, Pizza_id = pizza.Pizza_id }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<PizzaRecipe> AddPizza(PizzaRecipe pizza)
        {
            return (await Connection.QueryAsync<PizzaRecipe>("AddPizzas", new { Name = pizza.Name, Price = pizza.Price }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<PizzaRecipe> DeletePizza(PizzaRecipe pizza)
        {
            return (await Connection.QueryAsync<PizzaRecipe>("DeletePizzasV2", new { Name = pizza.Name, Price = pizza.Price }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<PizzaRecipe> EditPizza(PizzaRecipe pizza)
        {
            return (await Connection.QueryAsync<PizzaRecipe>("EditPizzas", new { ID = pizza.ID, Name = pizza.Name, Price = pizza.Price }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }
        public async Task<IEnumerable<PizzaRecipe>> GetPizzas()
        {
            return (await Connection.QueryAsync<PizzaRecipe>("GetPizzas", null, commandType: CommandType.StoredProcedure));
        }
        public async Task<IEnumerable<PizzaRecipe>> GetCurrentpizzas()
        {
            return (await Connection.QueryAsync<PizzaRecipe>("GetCurrentpizzas", null, commandType: CommandType.StoredProcedure));
        }
        #endregion

        #region Pastas
        public async Task<Pasta> AddPasta(Pasta pasta)
        {
            return (await Connection.QueryAsync<Pasta>("AddPasta", new { Name = pasta.Name, Price = pasta.Price }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<Pasta> DeletePasta(Pasta pasta)
        {
            return (await Connection.QueryAsync<Pasta>("DeletePasta", new { Name = pasta.Name, Price = pasta.Price }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<Pasta> EditPasta(Pasta pasta)
        {
            return (await Connection.QueryAsync<Pasta>("EditPasta", new { ID = pasta.ID, Name = pasta.Name, Price = pasta.Price }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }
        public async Task<IEnumerable<Pasta>> GetPastas()
        {
            return (await Connection.QueryAsync<Pasta>("GetPastas", null, commandType: CommandType.StoredProcedure));
        }
        #endregion

        #region Sallads
        public async Task<Sallad> AddSallad(Sallad sallad)
        {
            return (await Connection.QueryAsync<Sallad>("AddSallad", new { Name = sallad.Name, Price = sallad.Price }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<Sallad> DeleteSallad(Sallad sallad)
        {
            return (await Connection.QueryAsync<Sallad>("DeleteSallad", new { Name = sallad.Name, Price = sallad.Price }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<Sallad> EditSallad(Sallad sallad)
        {
            return (await Connection.QueryAsync<Sallad>("EditSallad", new { ID = sallad.ID, Name = sallad.Name, Price = sallad.Price }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }
        public async Task<IEnumerable<Sallad>> GetSallads()
        {
            return (await Connection.QueryAsync<Sallad>("GetSallads", null, commandType: CommandType.StoredProcedure));
        }
        #endregion

        #region Beverages
        public async Task<Beverage> AddBeverage(Beverage beverage)
        {
            return (await Connection.QueryAsync<Beverage>("AddBeverage", new { Name = beverage.Name, Price = beverage.Price }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<Beverage> DeleteBeverage(Beverage beverage)
        {
            return (await Connection.QueryAsync<Beverage>("DeleteBeverage", new { Name = beverage.Name, Price = beverage.Price }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<Beverage> EditBeverage(Beverage beverage)
        {
            return (await Connection.QueryAsync<Beverage>("EditBeverage", new { ID = beverage.ID, Name = beverage.Name, Price = beverage.Price }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }
        public async Task<IEnumerable<Beverage>> GetBeverages()
        {
            return (await Connection.QueryAsync<Beverage>("GetBeverages", null, commandType: CommandType.StoredProcedure));
        }
        #endregion

        #region Ingredients
        public async Task<Ingredient> AddIngredient(Ingredient ingredient)
        {
            return (await Connection.QueryAsync<Ingredient>("AddIngredient", new { Name = ingredient.Name, Price = ingredient.Price }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<Ingredient> DeleteIngredient(Ingredient ingredient)
        {
            return (await Connection.QueryAsync<Ingredient>("DeleteIngredient", new { Name = ingredient.Name, Price = ingredient.Price }, commandType: CommandType.StoredProcedure)).First();
        }
        public async Task<Ingredient> EditIngredient(Ingredient ingredient)
        {
            return (await Connection.QueryAsync<Ingredient>("EditIngredient", new { ID = ingredient.ID, Name = ingredient.Name, Price = ingredient.Price }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
        }
        public async Task<IEnumerable<Ingredient>> GetIngredients()
        {
            return (await Connection.QueryAsync<Ingredient>("GetIngredients", null, commandType: CommandType.StoredProcedure));
        }
        #endregion


        public void Dispose()
        {
            Connection.Close();
        }
    }
}
public class PgsRepository : IDisposable, IRepository
{
    IDbConnection Connection { get; set; }

    public string ConnectionString { get; } = "Server=weboholics-demo.dyndns-ip.com;Port=5433;Database=grupp2;User Id = grupp2; Password=grupp2";

    public PgsRepository()
    {
        Connection = new NpgsqlConnection(ConnectionString);
        Connection.Open();
    }
    #region Orders
    public async Task<IEnumerable<Order>> GetOrdersMaking()
    {
        return (await Connection.QueryAsync<Order>("GetOrdersMaking", null, commandType: CommandType.StoredProcedure));
    }
    public async Task<IEnumerable<Order>> GetOrdersMakingtwo()
    {
        return (await Connection.QueryAsync<Order>("GetOrdersMakingtwo", null, commandType: CommandType.StoredProcedure));
    }
    public async Task<Order> DeleteOrders(Order Order)
    {
        return (await Connection.QueryAsync<Order>("DeleteOrders", new { _ID = Order.ID }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }
    public async Task<Order> AddNewOrder(Order Order)
    {
        return (await Connection.QueryAsync<Order>("AddNewOrder", new { _Order_status = Order.Order_status }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }
    public async Task<IEnumerable<Order>> GetOrders()
    {
        return (await Connection.QueryAsync<Order>("GetOrders", null, commandType: CommandType.StoredProcedure));
    }
    public async Task<IEnumerable<PizzaRecipe>> GetCurrentpizzas()
    {
        return (await Connection.QueryAsync<PizzaRecipe>("GetCurrentpizzas", null, commandType: CommandType.StoredProcedure));
    }
    #endregion

    #region Employees
    public async Task<Employee> AddEmployee(Employee employee)
    {
        return (await Connection.QueryAsync<Employee>("AddEmployee", new { _Username = employee.Username, _Password = employee.Password, _Role = employee.Role }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }
    public async Task<Employee> DeleteEmployee(Employee employee)
    {
        return (await Connection.QueryAsync<Employee>("DeleteEmployee", new { _Username = employee.Username, _Password = employee.Password, _Role = employee.Role }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }
    public async Task<Employee> EditEmployee(Employee employee)
    {
        return (await Connection.QueryAsync<Employee>("EditEmployee", new { _ID = employee.ID, _Username = employee.Username, _Password = employee.Password, _Role = employee.Role }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }
    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        return (await Connection.QueryAsync<Employee>("GetEmployees", null, commandType: CommandType.StoredProcedure));
    }
    #endregion

    #region Pizzas
    public async Task<PizzaRecipe> AddPizza(PizzaRecipe pizza)
    {
        return (await Connection.QueryAsync<PizzaRecipe>("AddPizzas", new { _Name = pizza.Name, _Price = pizza.Price }, commandType: CommandType.StoredProcedure)).First();
    }
    public async Task<PizzaRecipe> DeletePizza(PizzaRecipe pizza)
    {
        return (await Connection.QueryAsync<PizzaRecipe>("DeletePizzasV2", new { _Name = pizza.Name, _Price = pizza.Price }, commandType: CommandType.StoredProcedure)).First();
    }
    public async Task<PizzaRecipe> EditPizza(PizzaRecipe pizza)
    {
        return (await Connection.QueryAsync<PizzaRecipe>("EditPizzas", new { _ID = pizza.ID, _Name = pizza.Name, _Price = pizza.Price }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }
    public async Task<IEnumerable<PizzaRecipe>> GetPizzas()
    {
        return (await Connection.QueryAsync<PizzaRecipe>("GetPizzas", null, commandType: CommandType.StoredProcedure));
    }
    public async Task<PizzaRecipe> AddNewPizzaContent(PizzaRecipe pizza)
    {
        return (await Connection.QueryAsync<PizzaRecipe>("AddNewPizzaContent", new { _Ingredients_id = pizza.Ingredient_id, _Pizza_id = pizza.Pizza_id }, commandType: CommandType.StoredProcedure)).First();
    }
    #endregion

    #region Pastas
    public async Task<Pasta> AddPasta(Pasta pasta)
    {
        return (await Connection.QueryAsync<Pasta>("AddPasta", new { _Name = pasta.Name, _Price = pasta.Price }, commandType: CommandType.StoredProcedure)).First();
    }
    public async Task<Pasta> DeletePasta(Pasta pasta)
    {
        return (await Connection.QueryAsync<Pasta>("DeletePasta", new { _Name = pasta.Name, _Price = pasta.Price }, commandType: CommandType.StoredProcedure)).First();
    }
    public async Task<Pasta> EditPasta(Pasta pasta)
    {
        return (await Connection.QueryAsync<Pasta>("EditPasta", new { _ID = pasta.ID, _Name = pasta.Name, _Price = pasta.Price }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }
    public async Task<IEnumerable<Pasta>> GetPastas()
    {
        return (await Connection.QueryAsync<Pasta>("GetPastas", null, commandType: CommandType.StoredProcedure));
    }
    #endregion

    #region Sallads
    public async Task<Sallad> AddSallad(Sallad sallad)
    {
        return (await Connection.QueryAsync<Sallad>("AddSallad", new { _Name = sallad.Name, _Price = sallad.Price }, commandType: CommandType.StoredProcedure)).First();
    }
    public async Task<Sallad> DeleteSallad(Sallad sallad)
    {
        return (await Connection.QueryAsync<Sallad>("DeleteSallad", new { _Name = sallad.Name, _Price = sallad.Price }, commandType: CommandType.StoredProcedure)).First();
    }
    public async Task<Sallad> EditSallad(Sallad sallad)
    {
        return (await Connection.QueryAsync<Sallad>("EditSallad", new { _ID = sallad.ID, _Name = sallad.Name, _Price = sallad.Price }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }
    public async Task<IEnumerable<Sallad>> GetSallads()
    {
        return (await Connection.QueryAsync<Sallad>("GetSallads", null, commandType: CommandType.StoredProcedure));
    }
    #endregion

    #region Beverages
    public async Task<Beverage> AddBeverage(Beverage beverage)
    {
        return (await Connection.QueryAsync<Beverage>("AddBeverage", new { _Name = beverage.Name, _Price = beverage.Price }, commandType: CommandType.StoredProcedure)).First();
    }
    public async Task<Beverage> DeleteBeverage(Beverage beverage)
    {
        return (await Connection.QueryAsync<Beverage>("DeleteBeverage", new { _Name = beverage.Name, _Price = beverage.Price }, commandType: CommandType.StoredProcedure)).First();
    }
    public async Task<Beverage> EditBeverage(Beverage beverage)
    {
        return (await Connection.QueryAsync<Beverage>("EditBeverage", new { _ID = beverage.ID, _Name = beverage.Name, _Price = beverage.Price }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }
    public async Task<IEnumerable<Beverage>> GetBeverages()
    {
        return (await Connection.QueryAsync<Beverage>("GetBeverages", null, commandType: CommandType.StoredProcedure));
    }
    #endregion

    #region Ingredients
    public async Task<Ingredient> AddIngredient(Ingredient ingredient)
    {
        return (await Connection.QueryAsync<Ingredient>("AddIngredient", new { _Name = ingredient.Name, _Price = ingredient.Price }, commandType: CommandType.StoredProcedure)).First();
    }
    public async Task<Ingredient> DeleteIngredient(Ingredient ingredient)
    {
        return (await Connection.QueryAsync<Ingredient>("DeleteIngredient", new { _Name = ingredient.Name, _Price = ingredient.Price }, commandType: CommandType.StoredProcedure)).First();
    }
    public async Task<Ingredient> EditIngredient(Ingredient ingredient)
    {
        return (await Connection.QueryAsync<Ingredient>("EditIngredient", new { _ID = ingredient.ID, _Name = ingredient.Name, _Price = ingredient.Price }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
    }
    public async Task<IEnumerable<Ingredient>> GetIngredients()
    {
        return (await Connection.QueryAsync<Ingredient>("GetIngredients", null, commandType: CommandType.StoredProcedure));
    }
    #endregion

    public void Dispose()
    {
        Connection.Close();
    }
}

