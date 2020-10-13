using System;
namespace AtletikaiVerseny
{
    internal class atleta
    {
        public string Rajtszam { get;private set; }
        
        public string VezNev { get; private set; }
        public string KezNev  { get;private set; }
        public string Egyesulet  { get;private set; }
        public int Ugras  { get;private set; }
        public atleta(string sor)
        {
            string[] sed = sor.Split(';');
            Rajtszam = sed[0];
            string[] fd = sed[1].Split(' ');
            VezNev = fd[0];
            KezNev = fd[1];
            Egyesulet = sed[2];
            Ugras =int.Parse( sed[3]);

        }
        public string Nev()
        {
            
            return VezNev+" "+KezNev;
           
        }
    }
}