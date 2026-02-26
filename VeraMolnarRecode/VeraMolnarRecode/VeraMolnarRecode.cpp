#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

int main() 
{
    srand(time(0));

    const int rows = 20;
    const int cols = 40;

    for (int y = 0; y < rows; y++) 
    {
        for (int x = 0; x < cols; x++) 
        {
            // random interuption
            if (rand() % 100 < 15) 
            {
                cout << "  ";   // blank space
                continue;
            }

            // chosing the line type to give the rotation effect
            int r = rand() % 4;

            // 4 differnt lines to choose from
            if (r == 0) cout << "--";
            else if (r == 1) cout << "| ";
            else if (r == 2) cout << "/ ";
            else cout << "\\ ";

        }
        cout << endl;
    }

    return 0;
}