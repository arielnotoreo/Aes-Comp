#include <iostream>
#include <cstdlib>
#include <ctime>
#include <fstream>

using namespace std;

int main() 
{
    srand(time(0));

    const int rows = 20;
    const int cols = 40;

    //open svg file
    ofstream svgFile("veramolnar.svg");

    if (svgFile.is_open())
    {
        // the header?? lowkey dont really know what this means tbh
        svgFile << "<svg width=\"40\" height=\"20\" xmlns=\"http://www.w3.org/2000/svg\">\n";

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                // random interuption
                if (rand() % 100 < 15)
                {
                    svgFile << "  ";   // blank space
                    cout << "  ";
                    continue;
                }

                // chosing the line type to give the rotation effect
                int r = rand() % 4;

                // 4 differnt lines to choose from
                switch (r)
                {
                case 0:
                    svgFile << "<text x='10' y='30' font-size='20' fill='black'>--</text>";
                    cout << "--";
                    break;
                case 1:
                    svgFile << "| ";
                    cout << "|";
                    break;
                case 2:
                    svgFile << "/ ";
                    cout << "/";
                    break;
                default:
                    svgFile << "\\";
                    cout << "\\";
                    break;
                }
            }
        }

        svgFile << "</svg>";
        svgFile.close();

        cout << "file created" << endl;
    }
    else
    {
        cerr << "error opening file" << endl;
    }
   
    return 0;
}