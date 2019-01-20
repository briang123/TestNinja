namespace TestNinja.Mocking
{
    public class Product
    {
        public float ListPrice { get; set; }

        public float GetPrice(Customer customer)
        {
            if (customer.IsGold)
                return ListPrice * 0.7f;

            return ListPrice;
        }

        // TO DEMONSTRATE WHAT NOT TO DO -- MOCKING UNNECESSARILY
        public float GetPrice(ICustomer customer)
        {
            if (customer.IsGold)
                return ListPrice * 0.7f;

            return ListPrice;
        }

    }

    public interface ICustomer
    {
        bool IsGold { get; set; }
    }

    public class Customer : ICustomer
    {
        public bool IsGold { get; set; }
    }
}