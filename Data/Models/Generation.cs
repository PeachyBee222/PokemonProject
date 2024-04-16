namespace TheFlyingSaucer.Data.Models
{
    public class Generation
    {
        public int GenNum { get; private set; }
        public string GenName { get; private set; }

        public int GenUsers { get; private set; }

        public Generation(int genNum, int users)
        {
            GenNum = genNum;
            GenUsers = users;
            SetGenName(genNum);
        }

        public Generation(string genName, int users)
        {
            GenName = genName;
            GenUsers = users;
            SetGenNum(genName);
        }

        private void SetGenName (int genNum)
        {
            switch (genNum)
            {
                case 0:
                    GenName = "User Created";
                    break;
                case 1:
                    GenName = "Science";
                    break;
                case 2:
                    GenName = "Cultural Traditions";
                    break;
                case 3:
                    GenName = "The Environment";
                    break;
                case 4:
                    GenName = "Time and Space";
                    break;
                case 5:
                    GenName = "Truth and Ideals";
                    break;
                case 6:
                    GenName = "Life, Death, and the Ecosystem";
                    break;
                case 7:
                    GenName = "Day and Night";
                    break;
                case 8:
                    GenName = "England and It's Culture";
                    break;
                case 9:
                    GenName = "Past vs. the Future";
                    break;
                default:
                    GenName = "Default";
                    break;
            }
        }

        private void SetGenNum(string genName)
        {
            switch (genName)
            {
                case "User Created":
                    GenNum = 0;
                    break;
                case "Science":
                    GenNum = 1;
                    break;
                case "Cultural Traditions":
                    GenNum = 2;
                    break;
                case "The Environment":
                    GenNum = 3;
                    break;
                case "Time and Space":
                    GenNum = 4;
                    break;
                case "Truth and Ideals":
                    GenNum = 5;
                    break;
                case "Life, Death, and the Ecosystem":
                    GenNum = 6;
                    break;
                case "Day and Night":
                    GenNum = 7;
                    break;
                case "England and It's Culture":
                    GenNum = 8;
                    break;
                case "Past vs. the Future":
                    GenNum = 9;
                    break;
                default:
                    GenNum = 0;
                    break;
            }
        }
    }
}
