namespace GiftShop.Common
{
    public static class ModelValidationConstants
    {
        public static class Product
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 50;

            public const int SizeMinLenght = 2; 
            public const int SizeMaxLenght = 20;

            public const int DescriptionMinLenght = 2;
            public const int DescriptionMaxLenght = 1000;
            public const string QuantityErrorMessage = "Quantity Exceeded! Please select a smaller quantity for your order.";

        }
        public static class ProductType
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 20;
        }
        public static class YarnType
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 50;
        }
        public static class Packaging
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 50;
        }

        public class Customer
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 50;
            public const int AddressMinLenght = 2;
            public const int AddressMaxLenght = 50;

        }

        public class DeliveryCompany
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 50;
        }

        public class Image
        {
            public const int UrlMinLenght = 7;
            public const int UrlMaxLenght = 2083;
        }
    }
}
