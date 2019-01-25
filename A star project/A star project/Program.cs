using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_star_project
{
    class Program
    {
        static void Main(string[] args)
        {
             
     //1--> The cell is not blocked 
     //0--> The cell is blocked    
    int grid[ROW][COL]; 
     
        { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 }, 
        { 1, 1, 1, 0, 1, 1, 1, 0, 1, 1 }, 
        { 1, 1, 1, 0, 1, 1, 0, 1, 0, 1 }, 
        { 0, 0, 1, 0, 1, 0, 0, 0, 0, 1 }, 
        { 1, 1, 1, 0, 1, 1, 1, 0, 1, 0 }, 
        { 1, 0, 1, 1, 1, 1, 0, 1, 0, 0 }, 
        { 1, 0, 0, 0, 0, 1, 0, 0, 0, 1 }, 
        { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 }, 
        { 1, 1, 1, 0, 0, 0, 1, 0, 0, 1 } ,
    } 
  
    // Source is the left-most bottom-most corner 
    Pair src = make_pair(8, 0); 
  
    // Destination is the left-most top-most corner 
    Pair dest = make_pair(0, 0); 
  
    aStarSearch(grid, src, dest); 
        }
        internal static class DefineConstants
        {
            public const int ROW = 9;
            public const int COL = 10;
        }
        public static class GlobalMembers
{
	// this function is to check whether given cell (row, col) 
	// is a valid cell or not. 
public static bool isValid(int row, int col)
	{
		return (row >= 0) && (row < DefineConstants.ROW) && (col >= 0) && (col < DefineConstants.COL);
	}

	// this function is to check whether the given cell is blocked or not 
	public static bool isUnBlocked(int[][] grid, int row, int col)
	{
		if (grid[row][col] == 1)
		{

			return (true);
		}

		else
		{

			return (false);
		}
	}
            struct cell
            {
                int parent_i,parent_j;
                double f,g,h;
            }
            
	//this Function is made to check whether destination cell has been reached or not
	 public static bool isDestination(int row, int col,  pair<int, int> dest)
	{
       
		if (row == dest.first && col == dest.second)
		{

			return (true);
		}

		else
		{

			return (false);
		}
	}


	// Function to calculate the 'h' heuristics. 

	public static double calculateHValue(int row, int col, pair<int, int> dest)
	{
 		return ((double)Math.Sqrt((row - dest.first) * (row - dest.first) + (col - dest.second) * (col - dest.second)));
	}


	// we make this Function to trace the path from the source to destination 
	public static void tracePath(cell[,] cellDetails, pair<int, int> dest)
	{

		Console.Write("\nThe Path is ");

		int row = dest.first;

		int col = dest.second;



		stack<pair<int, int>> Path = new stack<pair<int, int>>();



		while (!(cellDetails[row,col].parent.i == row && cellDetails[row,col].parent_j == col))

		{

			Path.push(make_pair(row, col));

			int temp_row = cellDetails[row,col].parent_i;

			int temp_col = cellDetails[row,col].parent_j;

			row = temp_row;

			col = temp_col;

		}



		Path.push(make_pair(row, col));

		while (!Path.empty())

		{

			pair<int, int> p = Path.top();

			Path.pop();

			Console.Write("-> ({0:D},{1:D}) ", p.first, p.second);

		}



		return;
	}
// A Function to find the shortest path between  
	// to A* Search Algorithm 
	public static void aStarSearch(int[][] grid, pair<int, int> src, pair<int, int> dest)
	{
		// If the source is out of range 
		if (isValid(src.first, src.second) == false)

		{

			Console.Write("Source is invalid\n");

			return;

		}

		// If the destination is out of range 

		if (isValid(dest.first, dest.second) == false)

		{

			Console.Write("Destination is invalid\n");

			return;

		}



		// Either the source or the destination is blocked 

		if (isUnBlocked(grid, src.first, src.second) == false || isUnBlocked(grid, dest.first, dest.second) == false)

		{

			Console.Write("Source or the destination is blocked\n");

			return;

		}



		// If the destination cell is the same as source cell 

		if (isDestination(src.first, src.second, new pair<int, int>(dest)) == true)

		{

			Console.Write("We are already at the destination\n");

			return;

		}



		// Create a closed list and initialise it to false which means that no cell has been included yet This closed list is implemented as a boolean 2D array
 		bool[][] closedList = RectangularArrays.RectangularBoolArray(DefineConstants.ROW, DefineConstants.COL);

		// Declare a 2D array of structure to hold the details 
		//of that cell 
          internal static class RectangularArrays
{
    public static bool[][] RectangularBoolArray(int size1, int size2)
    {
        bool[][] newArray = new bool[size1][];
        for (int array1 = 0; array1 < size1; array1++)
        {
            newArray[array1] = new bool[size2];
        }

        return newArray;
    }
            }
    public  cell[][] RectangularCellArray(int size1, int size2)
    {
        cell[][] newArray = new cell[size1][];
        for (int array1 = 0; array1 < size1; array1++)
        {
            newArray[array1] = new cell[size2];
        }

       return newArray;
    }   
}
		cell[][] cellDetails = RectangularArrays.RectangularCellArray(DefineConstants.ROW, DefineConstants.COL);

		int i;
		int j;

		for (i = 0; i < DefineConstants.ROW; i++)

		{

			for (j = 0; j < DefineConstants.COL; j++)

			{

				cellDetails[i][j].f = FLT_MAX;

				cellDetails[i][j].g = FLT_MAX;

				cellDetails[i][j].h = FLT_MAX;

				cellDetails[i][j].parent_i = -1;

				cellDetails[i][j].parent_j = -1;

			}

		}

		// Initialising the parameters of the starting node 

		i = src.first;
        j = src.second;

		cellDetails[i][j].f = 0.0;

		cellDetails[i][j].g = 0.0;

		cellDetails[i][j].h = 0.0;

		cellDetails[i][j].parent_i = i;

		cellDetails[i][j].parent_j = j;
	
		/*Create an open list This open list is implenented as a set of pair of pair.*/
			
		set<pair<double, pair<int, int>>> openList = new set<pair<double, pair<int, int>>>();

		// Put the starting cell on the open list and set its 

		// 'f' as 0 

		openList.insert(make_pair(0.0, make_pair(i, j)));

		// We set this boolean value as false as initially 

		// the destination is not reached. 

		bool foundDest = false;

		while (!openList.empty())

		{

			pair<double, pair<int, int>> p = *openList.begin();

			// Remove this vertex from the open list 

			openList.erase(openList.begin());

			// Add this vertex to the closed list 

			i = p.second.first;

			j = p.second.second;

			closedList[i][j] = true;

			//Generating all the 8 successor of this cell	
			// To store the 'g', 'h' and 'f' of the 8 successors 

			double gNew;
			double hNew;
			double fNew;
			//1st Successor (North)  
			// Only process this cell if this is a valid one 

			if (isValid(i - 1, j) == true)

			{
 				if (isDestination(i - 1, j, new pair<int, int>(dest)) == true)

                {
					cellDetails[i - 1][j].parent_i = i;

					cellDetails[i - 1][j].parent_j = j;

					Console.Write("The destination cell is found\n");

					tracePath(cellDetails, new pair<int, int>(dest));

					foundDest = true;

					return;

				}
				else if (closedList[i - 1][j] == false && isUnBlocked(grid, i - 1, j) == true)

				{

					gNew = cellDetails[i][j].g + 1.0;

					hNew = calculateHValue(i - 1, j, new pair<int, int>(dest));

					fNew = gNew + hNew;
			
					if (cellDetails[i - 1][j].f == FLT_MAX || cellDetails[i - 1][j].f > fNew)

					{
						openList.insert(make_pair(fNew, make_pair(i - 1, j)));

						// Update the details of this cell 

						cellDetails[i - 1][j].f = fNew;

						cellDetails[i - 1][j].g = gNew;

						cellDetails[i - 1][j].h = hNew;

						cellDetails[i - 1][j].parent_i = i;

						cellDetails[i - 1][j].parent_j = j;

					}

				}

			}
			//----------- 2nd Successor (South) ------------ 
			// Only process this cell if this is a valid one 

			if (isValid(i + 1, j) == true)

			{
				if (isDestination(i + 1, j, new pair<int, int>(dest)) == true)

				{

					// Set the Parent of the destination cell 

					cellDetails[i + 1][j].parent_i = i;

					cellDetails[i + 1][j].parent_j = j;

					Console.Write("The destination cell is found\n");

					tracePath(cellDetails, new pair<int, int>(dest));
                }

    }
//----------- 3rd Successor (East) ------------ 
  
        // Only process this cell if this is a valid one 
        if (isValid (i, j+1) == true) 
        { 
            if (isDestination(i, j+1, dest) == true) 
            { 
                cellDetails[i][j+1].parent_i = i; 
                cellDetails[i][j+1].parent_j = j; 
                printf("The destination cell is found\n"); 
                tracePath(cellDetails, dest); 
                foundDest = true; 
                return; 
            } 
            else if (closedList[i][j+1] == false && 
                     isUnBlocked (grid, i, j+1) == true) 
            { 
                gNew = cellDetails[i][j].g + 1.0; 
                hNew = calculateHValue (i, j+1, dest); 
                fNew = gNew + hNew; 
                if (cellDetails[i][j+1].f == FLT_MAX || 
                        cellDetails[i][j+1].f > fNew) 
                { 
                    openList.insert( make_pair(fNew, 
                                        make_pair (i, j+1))); 
  
                    // Update the details of this cell 
                    cellDetails[i][j+1].f = fNew; 
                    cellDetails[i][j+1].g = gNew; 
                    cellDetails[i][j+1].h = hNew; 
                    cellDetails[i][j+1].parent_i = i; 
                    cellDetails[i][j+1].parent_j = j; 
                } 
            } 
        } 
  
        //----------- 4th Successor (West) ------------  
        // Only process this cell if this is a valid one 
        if (isValid(i, j-1) == true) 
        { 
            if (isDestination(i, j-1, dest) == true) 
            { 
                cellDetails[i][j-1].parent_i = i; 
                cellDetails[i][j-1].parent_j = j; 
                printf("The destination cell is found\n"); 
                tracePath(cellDetails, dest); 
                foundDest = true; 
                return; 
            } 
  else if (closedList[i][j-1] == false && 
                     isUnBlocked(grid, i, j-1) == true) 
            { 
                gNew = cellDetails[i][j].g + 1.0; 
                hNew = calculateHValue(i, j-1, dest); 
                fNew = gNew + hNew; 
                if (cellDetails[i][j-1].f == FLT_MAX || 
                        cellDetails[i][j-1].f > fNew) 
                { 
                    openList.insert( make_pair (fNew, 
                                          make_pair (i, j-1))); 
  
                    // Update the details of this cell 
                    cellDetails[i][j-1].f = fNew; 
                    cellDetails[i][j-1].g = gNew; 
                    cellDetails[i][j-1].h = hNew; 
                    cellDetails[i][j-1].parent_i = i; 
                    cellDetails[i][j-1].parent_j = j; 
                } 
            } 
        } 
  
        //----------- 5th Successor (North-East) ------------ 
  
        // Only process this cell if this is a valid one 
        if (isValid(i-1, j+1) == true) 
        { 
            if (isDestination(i-1, j+1, dest) == true) 
            { 
                cellDetails[i-1][j+1].parent_i = i; 
                cellDetails[i-1][j+1].parent_j = j; 
                printf ("The destination cell is found\n"); 
                tracePath (cellDetails, dest); 
                foundDest = true; 
                return; 
            } 
            else if (closedList[i-1][j+1] == false && 
                     isUnBlocked(grid, i-1, j+1) == true) 
            { 
                gNew = cellDetails[i][j].g + 1.414; 
                hNew = calculateHValue(i-1, j+1, dest); 
                fNew = gNew + hNew; 
                if (cellDetails[i-1][j+1].f == FLT_MAX || 
                        cellDetails[i-1][j+1].f > fNew) 
                { 
                    openList.insert( make_pair (fNew,  
                                    make_pair(i-1, j+1))); 
  
                    // Update the details of this cell 
                    cellDetails[i-1][j+1].f = fNew; 
                    cellDetails[i-1][j+1].g = gNew; 
                    cellDetails[i-1][j+1].h = hNew; 
                    cellDetails[i-1][j+1].parent_i = i; 
                    cellDetails[i-1][j+1].parent_j = j; 
                } 
            } 
        } 
  
        //----------- 6th Successor (North-West) ------------ 
  
        // Only process this cell if this is a valid one 
        if (isValid (i-1, j-1) == true) 
        { 
            if (isDestination (i-1, j-1, dest) == true) 
            { 
                cellDetails[i-1][j-1].parent_i = i; 
                cellDetails[i-1][j-1].parent_j = j; 
                printf ("The destination cell is found\n"); 
                tracePath (cellDetails, dest); 
                foundDest = true; 
                return; 
            } 
  
            else if (closedList[i-1][j-1] == false && 
                     isUnBlocked(grid, i-1, j-1) == true) 
            { 
                gNew = cellDetails[i][j].g + 1.414; 
                hNew = calculateHValue(i-1, j-1, dest); 
                fNew = gNew + hNew; 
                if (cellDetails[i-1][j-1].f == FLT_MAX || 
                        cellDetails[i-1][j-1].f > fNew) 
                { 
                    openList.insert( make_pair (fNew, make_pair (i-1, j-1))); 
                    // Update the details of this cell 
                    cellDetails[i-1][j-1].f = fNew; 
                    cellDetails[i-1][j-1].g = gNew; 
                    cellDetails[i-1][j-1].h = hNew; 
                    cellDetails[i-1][j-1].parent_i = i; 
                    cellDetails[i-1][j-1].parent_j = j; 
                } 
            } 
        } 
  
        //----------- 7th Successor (South-East) ------------ 
  
        // Only process this cell if this is a valid one 
        if (isValid(i+1, j+1) == true) 
        { 
            if (isDestination(i+1, j+1, dest) == true) 
            { 
                cellDetails[i+1][j+1].parent_i = i; 
                cellDetails[i+1][j+1].parent_j = j; 
                printf ("The destination cell is found\n"); 
                tracePath (cellDetails, dest); 
                foundDest = true; 
                return; 
            } 
            else if (closedList[i+1][j+1] == false && 
                     isUnBlocked(grid, i+1, j+1) == true) 
            { 
                gNew = cellDetails[i][j].g + 1.414; 
                hNew = calculateHValue(i+1, j+1, dest); 
                fNew = gNew + hNew; 
  
                if (cellDetails[i+1][j+1].f == FLT_MAX || 
                        cellDetails[i+1][j+1].f > fNew) 
                { 
                    openList.insert(make_pair(fNew,  
                                        make_pair (i+1, j+1))); 
  
                    // Update the details of this cell 
                    cellDetails[i+1][j+1].f = fNew; 
                    cellDetails[i+1][j+1].g = gNew; 
                    cellDetails[i+1][j+1].h = hNew; 
                    cellDetails[i+1][j+1].parent_i = i; 
                    cellDetails[i+1][j+1].parent_j = j; 
                } 
            } 
        } 
  
        //----------- 8th Successor (South-West) ------------ 
  
        // Only process this cell if this is a valid one 
        if (isValid (i+1, j-1) == true) 
        { 
            if (isDestination(i+1, j-1, dest) == true) 
            { 
                cellDetails[i+1][j-1].parent_i = i; 
                cellDetails[i+1][j-1].parent_j = j; 
                printf("The destination cell is found\n"); 
                tracePath(cellDetails, dest); 
                foundDest = true; 
                return; 
            } 
  
            else if (closedList[i+1][j-1] == false && 
                     isUnBlocked(grid, i+1, j-1) == true) 
            { 
                gNew = cellDetails[i][j].g + 1.414; 
                hNew = calculateHValue(i+1, j-1, dest); 
                fNew = gNew + hNew; 
                if (cellDetails[i+1][j-1].f == FLT_MAX || 
                        cellDetails[i+1][j-1].f > fNew) 
                { 
                    openList.insert(make_pair(fNew,  
                                        make_pair(i+1, j-1))); 
  
                    // Update the details of this cell 
                    cellDetails[i+1][j-1].f = fNew; 
                    cellDetails[i+1][j-1].g = gNew; 
                    cellDetails[i+1][j-1].h = hNew; 
                    cellDetails[i+1][j-1].parent_i = i; 
                    cellDetails[i+1][j-1].parent_j = j; 
                } 
            } 
        } 
// When the destination cell is not found and the open 
   
    if (foundDest == false) 
        printf("Failed to find the Destination Cell\n"); 
  
    return; 
} 
    } 
        
    
}
        
    }
}

        
    }
}
