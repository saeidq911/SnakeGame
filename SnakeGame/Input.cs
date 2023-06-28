using System.Windows.Forms;
using System.Collections;

namespace SnakeGame
{
    internal class Input
    {
        //loads list of availble buttons
        private static Hashtable keyTable = new Hashtable();

        //perform a check to see if a particular button is pressed
        public static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }

            return (bool)keyTable[key];
        }

        //detect if a keyboard button is pressed
        public static void ChangeState(Keys key, bool state)
        {

            keyTable[key] = state;
        }
    }
}