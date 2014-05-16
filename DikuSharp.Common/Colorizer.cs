using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DikuSharp.Common
{
    public class Colorizer
    {
        private static Color[ ] Colors = {
                                     new Color( 'r', "31", false ),
                                     new Color( 'R', "31", true  ),
                                     new Color( 'g', "32", false ),
                                     new Color( 'G', "32", true  ),
                                     new Color( 'y', "33", false ),
                                     new Color( 'Y', "33", true  ),
                                     new Color( 'b', "34", false ),
                                     new Color( 'B', "34", true  ),
                                     new Color( 'p', "35", false ),
                                     new Color( 'P', "35", true  ),
                                     new Color( 'c', "36", false ),
                                     new Color( 'C', "36", true  ),
                                     new Color( 'w', "37", false ),
                                     new Color( 'W', "37", true  ),
                                     new Color( 'd', "30", false ),
                                     new Color( 'D', "30", true  ),
                                     new Color( 'o', "36", false ),
                                     new Color( 'O', "36", true  ),
                                     new Color( 'l', "36", false ),
                                     new Color( 'L', "36", true  ),
                                     new Color( 't', "36", false ),
                                     new Color( 'T', "36", true  ),
                                     new Color( 'u', "36", false ),
                                     new Color( 'U', "36", true  ),
                                     new Color( 'm', "36", false ),
                                     new Color( 'M', "36", true  ),
                                     new Color( 'k', "36", false ),
                                     new Color( 'K', "36", true  ),
                                     new Color(  '\0', "", false )
                                 };

        public static string Colorize( string stringToColor, bool useColor )
        {
            bool bold = false;
            int last = -1;
            string output = "";

            for ( int i = 0; i < stringToColor.Length; i++ )
            {
                //Check for escape code
                if ( stringToColor[ i ] == '#' )
                {
                    i++;
                    //Let ## be a normal #, just in case
                    if ( stringToColor[ i ] == '#' )
                    {
                        output += '#';
                    }
                    else if ( stringToColor[ i ] == 'x' )
                    {
                        if ( last != -1 || bold )
                        {
                            bold = false;
                            output += "\x1B[0m";
                        }

                        last = -1;
                    }
                    else
                    {
                        bool validTag = false;

                        for (int j = 0; !string.IsNullOrWhiteSpace( Colorizer.Colors[j].Code ); j++)
                        {
                            if ( stringToColor[ i ] == Colorizer.Colors[ j ].Tag )
                            {
                                validTag = true;

                                //Only add it if it's needed
                                if ( last != j && useColor )
                                {
                                    bool sequence = false;

                                    output += "\x1B[";

                                    if ( last == -1 || last / 2 != j / 2 )
                                    {
                                        sequence = true;
                                    }

                                    if ( bold && Colorizer.Colors[ j ].IsBold == false )
                                    {
                                        output += '0';
                                        bold = false;

                                        output += ';';
                                        sequence = true;
                                    }
                                    else if ( !bold && Colorizer.Colors[ j ].IsBold == true )
                                    {
                                        output += '1';
                                        bold = true;

                                        if ( sequence )
                                        {
                                            output += ';';
                                        }
                                    }

                                    if ( sequence )
                                    {
                                        output += Colorizer.Colors[ j ].Code;
                                    }

                                    output += 'm';
                                }

                                last = j;
                            }
                        }

                        if ( !validTag )
                        {
                            output += '#';
                        }
                    }
                    //The next code should be our tag

                }
                else
                {
                    output += stringToColor[ i ];
                }
            }

            if ( last != -1 || bold )
            {
                output += "\x1B[0m";
            }
            output += '\0';

            return output;
        }

        private const string BOLD_RED = "{R";
        private const string RED = "{r";
        private const string BLUE = "{b";
        private const string BOLD_BLUE = "{B";
        private const string BLACK = "{d";
        private const string BOLD_BLACK = "{D";
        private const string YELLOW = "{y";
        private const string BOLD_YELLOW = "{Y";
        private const string WHITE = "{w";
        private const string BOLD_WHITE = "{W";
        private const string GREEN = "{g";
        private const string BOLD_GREEN = "{G";
        private const string CYAN = "{c";
        private const string BOLD_CYAN = "{C";
        private const string PURPLE = "{p";
        private const string BOLD_PURPLE = "{P";
        private const string ORANGE = "{o";
        private const string BOLD_ORANGE = "{O";
        private const string LIME = "{l";
        private const string BOLD_LIME = "{L";
        private const string TEAL = "{t";
        private const string BOLD_TEAL = "{T";
        private const string TURQUOISE = "{u";
        private const string BOLD_TURQUOISE = "{U";
        private const string MAGENTA = "{m";
        private const string BOLD_MAGENT = "{M";
        private const string PINK = "{k";
        private const string BOLD_PINK = "{K";
        private const string NORMAL = "{x";
    }
}
