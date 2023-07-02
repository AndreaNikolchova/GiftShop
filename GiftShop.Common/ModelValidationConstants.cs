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
        }
        public static class ProductType
        {
            public const int NameMinLenght = 2;
            public const int NameMaxLenght = 20;
        }
    }
}
