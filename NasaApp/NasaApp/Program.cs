using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            List<string> input = new List<string>();
            List<string[]> message=new List<string[]>();
            int i=0,j=0,k=0,l=0,sum=0,characters=0,z,x=0;
            string msg = "";
                
            #endregion

            #region Memory configuration of satellites

            Console.WriteLine("Enter word capacity of satelite 1");
            int m1=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter word capacity of satelite 2");
            int m2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter word capacity of satelite 3");
            int m3 = Convert.ToInt32(Console.ReadLine());
            string[] satellite1 = new string[m1];
            string[] satellite2 = new string[m2];
            string[] satellite3 = new string[m3];

            #endregion

            #region Read Messages

            Console.WriteLine("How many messages to send?");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter messages");
            for(i=0;i<n;i++)
            {
                Console.Write(i+1+" ");
                input.Add(Console.ReadLine());
            }

            #endregion

            #region Send Messages

            foreach(string val in input)
            {
                message.Add(val.Split(' '));
            }
            foreach(string[] words in message)
            {
                msg = "";
                i = 0; j = 0; k = 0; l = 0; sum = 0;

                #region Memory release and storage

                for (z=0;z<words.Length;z++)
                {
                    msg += words[z]+" ";

                    if (words[z].Length == 2 && !satellite1.Any(item => item == words[z]))
                    {
                        //releasing memory when new value comes and storage space is not available
                        if (j == m1)
                        {
                            for (i = 1; i < j; i++)
                            { satellite1[i - 1] = satellite1[i]; }
                            j -= 1;
                        }
                        //storing value in Satellite1
                        satellite1[j] = words[z]; j++; 
                    }

                    if (words[z].Length == 3 && !satellite2.Any(item => item == words[z]))
                    {
                        //releasing memory when new value comes and storage space is not available
                        if (k == m2)
                        {
                            for (i = 1; i < k; i++)
                            { satellite2[i - 1] = satellite2[i]; }
                            k -= 1;
                        }
                        //storing value in Satellite2
                        satellite2[k] = words[z]; k++; 
                    }

                    if (words[z].Length == 4 && !satellite3.Any(item=>item==words[z]))
                    {
                        //releasing memory when new value comes and storage space is not available
                        if (l == m3)
                        {
                            for (i = 1; i < l; i++)
                            { satellite3[i - 1] = satellite3[i]; }
                            l -= 1;
                        }
                        //storing value in Satellite3
                        satellite3[l] = words[z]; l++;
                    }
                }

                #endregion

                characters = input[x].Length; x++;
                sum += characters;
                int charactersS1 = 0, charactersS2=0, charactersS3=0;

                #region 1st satellite will transfer the data except the data in satellite 1


                if (j>0)
                {
                    for (z = satellite1.Length - 1; z >= 0 && satellite1[z] != null; z--)
                    {
                        charactersS1 += satellite1[z].Length;
                    }
                    sum += (characters - charactersS1)* 5;
                }
                else
                    sum += characters * 5;

                #endregion

                #region 2nd satellite will transfer the left out data(not in satellite 1 & 2)

                if (k > 0)
                {
                    for (z = satellite2.Length - 1; z >= 0 && satellite2[z] != null; z--)
                    {
                        charactersS2 += satellite2[z].Length;
                    }
                    sum += (characters - charactersS2 - charactersS1) * 5;
                }
                else
                    sum += (characters - charactersS1) * 5;

                #endregion

                #region 3rd satellite data transfer

                if (l > 0)
                {
                    for (z = satellite3.Length - 1; z>=0 && satellite3[z] != null; z--)
                    {
                        charactersS3 += satellite3[z].Length;
                    }
                    /*sending all characters to NASA (according to outputs given)*/

                    sum += characters; //- charactersS3 - charactersS2 - charactersS1;
                }
                else
                sum += characters; //- charactersS2 - charactersS1;

                #endregion

                Console.WriteLine("\n"+msg+", "+sum+" hours");
            }

            #endregion

            Console.ReadKey();
        }
    }
}
