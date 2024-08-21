using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class ListCloner
    {
        /// <summary>
        /// Clones a 3D list (List of List of List of doubles).
        /// </summary>
        /// <param name="oldList">The 3D list to clone.</param>
        /// <returns>A new 3D list that is a clone of the old list.</returns>
        public static List<List<List<double>>> CloneList(List<List<List<double>>> oldList)
        {
            // Create a new 3D list to hold the cloned data
            List<List<List<double>>> newList = new List<List<List<double>>>();

            // Get the dimensions of the old list
            int iterationCount = oldList.Count;    // Number of tables in the 3D list
            int rowCount = oldList[0].Count;       // Number of rows in each table
            int colCount = oldList[0][0].Count;    // Number of columns in each row

            // Iterate over each table in the old list
            for (int i = 0; i < iterationCount; i++)
            {
                // Create a new table (2D list) for the cloned data
                var table = new List<List<double>>();

                // Iterate over each row in the current table
                for (int j = 0; j < rowCount; j++)
                {
                    // Create a new row for the cloned data
                    var row = new List<double>();

                    // Iterate over each element in the current row
                    for (int k = 0; k < colCount; k++)
                    {
                        // Add the element to the new row
                        row.Add(oldList[i][j][k]);
                    }

                    // Add the new row to the new table
                    table.Add(row);
                }

                // Add the new table to the new 3D list
                newList.Add(table);
            }

            // Return the cloned 3D list
            return newList;
        }

        /// <summary>
        /// Clones a 2D list (List of List of doubles).
        /// </summary>
        /// <param name="oldList">The 2D list to clone.</param>
        /// <returns>A new 2D list that is a clone of the old list.</returns>
        public static List<List<double>> CloneList(List<List<double>> oldList)
        {
            // Create a new 2D list to hold the cloned data
            List<List<double>> newList = new List<List<double>>();

            // Get the dimensions of the old list
            int rowCount = oldList.Count;        // Number of rows in the 2D list
            int colCount = oldList[0].Count;     // Number of columns in each row

            // Iterate over each row in the old list
            for (int i = 0; i < rowCount; i++)
            {
                // Create a new row for the cloned data
                var newRow = new List<double>();

                // Iterate over each element in the current row
                for (int j = 0; j < colCount; j++)
                {
                    // Add the element to the new row
                    newRow.Add(oldList[i][j]);
                }

                // Add the new row to the new 2D list
                newList.Add(newRow);
            }

            // Return the cloned 2D list
            return newList;
        }
    }
}
