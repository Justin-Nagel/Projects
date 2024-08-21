using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    internal class Program
    {
        public enum Menu
        {
            menuBreakfast = 1,
            menuCombos,
            menuChips,
            menuBurgers,
            menuDrinks,
            checkout,
            exit
        }
        private static void breakfastMenu()
        {
            Console.WriteLine("- -Breakfast menu- -");
            Console.WriteLine("1. Breakfast combo: Burger with egg, chips, and a small coffee. - R35");
            Console.WriteLine("2. Chicken breakfast burger - R20");
            Console.WriteLine("3. Beef breakfast burger - R22");
            Console.WriteLine("4. Coffee - R15");
            Console.WriteLine("5. Back");
            Console.WriteLine("=========================");
        }
        
        private static void comboMenu()
        {
            Console.WriteLine("- -Combo menu- -");
            Console.WriteLine("1. Breakfast combo: Burger with egg, chips, and a small coffee. - R35");
            Console.WriteLine("2. Two chicken wrap with chips and a medium cooldrink - R50");
            Console.WriteLine("3. Four beef burgers with chips - R65");
            Console.WriteLine("4. Back");
            Console.WriteLine("=========================");
        }

        private static void chipsMenu()
        {
            Console.WriteLine("- -Chips only menu- -");
            Console.WriteLine("1. Small chips - R10");
            Console.WriteLine("2. Medium chips - R12");
            Console.WriteLine("3. Large chips - R14");
            Console.WriteLine("4. Back");
            Console.WriteLine("=========================");
        }

        private static void burgerMenu()
        {
            Console.WriteLine("- -Burgers only menu- -");
            Console.WriteLine("1. Chicken burger - R15");
            Console.WriteLine("2. Beef burger - R18");
            Console.WriteLine("3. Vegan burger - R12");
            Console.WriteLine("4. Back");
            Console.WriteLine("=========================");
        }

        private static void drinksMenu()
        {
            Console.WriteLine("- -Drinks only menu- -");
            Console.WriteLine("DISCLAIMER: All drinks are 330ml");
            Console.WriteLine("1. Coke - R10");
            Console.WriteLine("2. Fanta - R10");
            Console.WriteLine("3. Juice - R10");
            Console.WriteLine("4. Back");
            Console.WriteLine("=========================");
        }

        static void Main(string[] args)
        {           
            newOrder:
            double total = 0;
            int totalItems = 0;
            int breakfast, combo, chips, burgers, drinks;
            breakfast = 0;
            chips = 0;
            burgers = 0;
            drinks = 0;
            combo = 0;
            string itemBreakfast, itemCombo, itemChips, itemBurger, itemDrinks;
            itemBreakfast = "None";
            itemCombo = "None";
            itemChips = "None";
            itemBurger = "None";
            itemDrinks = "None";
            string newOrder;

            mainMenu:
            Console.Clear();
            Console.WriteLine("Welcome to No-Cents fast foods. What would you like to order?");
            Console.WriteLine("= = = = = = = = = = = = = = =");
            Console.WriteLine("1. Breakfast.");
            Console.WriteLine("2. Combos.");
            Console.WriteLine("3. Chips.");
            Console.WriteLine("4. Burgers.");
            Console.WriteLine("5. Drinks.");
            Console.WriteLine("6. Checkout.");
            Console.WriteLine("7. Exit.");
            Console.WriteLine("=========================");
            Console.WriteLine($"Total is currently: R{total}.");
            Console.WriteLine($"Total items: {totalItems}.");
            int menuNum = Convert.ToInt32(Console.ReadLine());
            
       
            switch ((Menu)menuNum)
            {
                case Menu.menuBreakfast: Console.Clear(); //enum menu 1
                    int breakfastNum;
                    breakfastMenu();
                    breakfastNum = Convert.ToInt32(Console.ReadLine());
                    
                    switch (breakfastNum)
                    {
                        case 1: total += 35;
                            totalItems++;
                            itemBreakfast = "Breakfast combo - R35";
                            breakfast++;
                            break;

                        case 2: total += 20;
                            totalItems++;
                            itemBreakfast = "Chicken breakfast burger - R20 ";
                            breakfast++;
                            break;

                        case 3: total += 22;
                            totalItems++;
                            itemBreakfast = "Beef breakfast burger - R22";
                            breakfast++;
                            break;

                        case 4: total += 15;
                            totalItems++;
                            itemBreakfast = "Coffee - R15";
                            breakfast++;
                            break;

                        case 5: goto mainMenu;
                            
                    }
                    goto mainMenu;

                case Menu.menuCombos: Console.Clear(); //enum menu 2
                    int comboNum;
                    comboMenu();
                    comboNum = Convert.ToInt32(Console.ReadLine());

                    switch (comboNum)
                    {
                        case 1:
                            total += 35;
                            totalItems++;
                            itemCombo = "Breakfast combo - R35";
                            combo++;
                            break;

                        case 2:
                            total += 50;
                            totalItems++;
                            itemCombo = "Two wrap combo - R50";
                            combo++;
                            break;

                        case 3:
                            total += 65;
                            totalItems++;
                            itemCombo = "Four beef burger combo - R65";
                            combo++;
                            break;

                        case 4: goto mainMenu;                         
                      
                    }
                    goto mainMenu;

                case Menu.menuChips: Console.Clear(); //enum menu 3
                    int chipsNum;
                    chipsMenu();
                    chipsNum = Convert.ToInt32(Console.ReadLine());

                    switch (chipsNum)
                    {
                        case 1: total += 10;
                            totalItems++;
                            itemChips = "Small chips - R10";
                            chips++;
                            break;

                        case 2: total += 12;
                            totalItems++;
                            itemChips = "Medium chips - R12";
                            chips++;
                            break;

                        case 3: total += 14;
                            totalItems++;
                            itemChips = "Large chips - R14";
                            chips++;
                            break;

                        case 4: goto mainMenu;
                            
                    }                   
                    goto mainMenu;

                case Menu.menuBurgers: Console.Clear(); //enum menu 4
                    int burgerNum;
                    burgerMenu();
                    burgerNum = Convert.ToInt32(Console.ReadLine());

                    switch (burgerNum)
                    {
                        case 1: total += 15;
                            totalItems++;
                            itemBurger = "Chicken burger - R15";
                            burgers++;
                            break;

                        case 2: total += 18;
                            totalItems++;
                            itemBurger = "Beef burger - R18";
                            burgers++;
                            break;

                        case 3: total += 21;
                            totalItems++;
                            itemBurger = "Vegan burger - R12";
                            burgers++;
                            break;

                        case 4: goto mainMenu;
                    }
                    goto mainMenu;

                case Menu.menuDrinks: Console.Clear(); //enum menu 5
                    int drinkNum;
                    drinksMenu();   
                    drinkNum = Convert.ToInt32(Console.ReadLine());

                    switch (drinkNum)
                    {
                        case 1:
                            total += 10;
                            totalItems++;
                            itemDrinks = "Coke - R10";
                            drinks++;
                            break;

                        case 2:
                            total += 10;
                            totalItems++;
                            itemDrinks = "Fanta - R10";
                            drinks++;
                            break;

                        case 3:
                            total += 10;
                            totalItems++;
                            itemDrinks = "Juice - R10";
                            drinks++;
                            break;

                        case 4: goto mainMenu;
                    }
                    goto mainMenu;

                case Menu.checkout: Console.Clear(); //enum menu 6
                    if (total == 0 || totalItems == 0)
                    {
                        Console.WriteLine("You haven't ordered anything, why check out, silly?");
                        Console.ReadKey();
                        goto newOrder;
                    }else
                    {
                        Console.WriteLine("- -Checkout- -");
                        if (itemBreakfast == "None")
                        {
                            Console.Write("");
                        }
                        else Console.WriteLine($"Breakfast({breakfast}): {itemBreakfast}");

                        if (itemCombo == "None")
                        {
                            Console.Write("");
                        }
                        else Console.WriteLine($"Combo({combo}): {itemCombo}");

                        if (itemChips == "None")
                        {
                            Console.Write("");
                        }
                        else Console.WriteLine($"Chips({chips}): {itemChips}");

                        if (itemBurger == "None")
                        {
                            Console.Write("");
                        }
                        else Console.WriteLine($"Burger({burgers}): {itemBurger}");

                        if (itemDrinks == "None")
                        {
                            Console.Write("");
                        }
                        else Console.WriteLine($"Drinks({drinks}): {itemDrinks}");

                        Console.WriteLine("=========================");
                        Console.WriteLine($"Total: R{total}");
                        Console.WriteLine($"Total items: {totalItems}");
                        Console.WriteLine("Thank you for ordering with us :)");
                        Console.WriteLine("= = = = = = = = = = = = = = =");
                        Console.WriteLine("Type 'Exit' to exit OR 'New Order' to place a new order.");
                        newOrder = Console.ReadLine();
                        if (newOrder == "New Order")
                        {
                            goto newOrder;
                        }
                        else if (newOrder == "Exit" || newOrder == "exit")
                        {
                            Environment.Exit(0);
                        }
                    }                   
                   break;

                case Menu.exit: Console.Clear(); //enum menu 7
                    Console.WriteLine("Are you sure you want to exit? All orders will be lost.");
                    string closeConfirm = Console.ReadLine();
                    if (closeConfirm == "Yes" || closeConfirm == "yes")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        goto mainMenu;
                    }
                    break;

                default:
                    Console.WriteLine("Please enter a valid number.");
                    Console.ReadKey();
                    goto newOrder;
            }
                     
            Console.ReadKey();
        }

        
    }

    
}
