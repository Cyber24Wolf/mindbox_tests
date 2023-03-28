using System;

namespace DatabaseUserIterface
{
    public class ShowCategoriesCommand : Command
    {
        private const string ALL_PRODUCTS_FLAG = "-all";
        private const int PRODUCT_NAME_INDEX = 1;

        public string CategoryName { get; private set; }

        private Program.ProgramState _programState;

        public ShowCategoriesCommand(Program.ProgramState programState, string categoryName)
        {
            _programState = programState;
            CategoryName = categoryName;
        }

        public ShowCategoriesCommand(Program.ProgramState programState) : this(programState, ALL_PRODUCTS_FLAG)
        {
        }

        public ShowCategoriesCommand(Program.ProgramState programState, string[] splittedString) :
                this (programState, SplittedStringArgsHandler.GetArgValueFromRawString(splittedString, PRODUCT_NAME_INDEX, defaultValue: ""))
        {
        }

        public override void Proceed()
        {
            if (string.IsNullOrEmpty(CategoryName))
            {
                Console.WriteLine("Invalid category name");
            }
            else if (CategoryName == ALL_PRODUCTS_FLAG)
            {
                _programState.Database.SendAllCategoriesQuery();
            }
            else
            {
                Console.WriteLine("PUT_SPECIFIC_QUERY_LOGIC_HERE");
            }
        }

        public static string GetSignatureDescription(bool forSpecificProduct)
        {
            return forSpecificProduct ? $"\"categories_of [product]\" - for showing categories of specific product" :
                                        $"\"categories_of -all\" - for showing categories of all products";
        }
    }
}
