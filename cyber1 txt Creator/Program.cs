using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.Text.Encoding;

namespace cyber1_txt_Creator {
    class Program {
        // Setup Vars
        private static readonly string Cyber1Dir = Directory.GetCurrentDirectory() + @"\cyber1";
        private static readonly string Cyber2Dir = Directory.GetCurrentDirectory() + @"\cyber2";
        private static readonly string ReadMeDir = Directory.GetCurrentDirectory() + @"\README";
        private static readonly string UndoneDir = Directory.GetCurrentDirectory() + @"\cyber2Undone";

        private static readonly string Key = "WarwickApplication";

        private static List<RowClass> Cyber1Data = new List<RowClass>() {
                new RowClass("CyberFirst Advanced", 
                    "summer school", 
                    "advanced", 
                    new DateTime(2021, 8, 16), 
                    10, 
                    "I participated in CyberFirst Advanced run by the National Cyber Security Centre. " +
                    "Here I earned the CyberFirst Advanced (SCQF Level 6) certificate."),
                new RowClass("Collins Aerospace Work Experience", "work/placement project", "", new DateTime(2021, 8, 2), 5, 
                    "I did work experience at Collins Aerospace - a company which is a pioneer in aerospace technology." +
                    " They taught me industry level cyber security and networking."),
                new RowClass("Borwells Ltd Work Experience", "work/placement project", "", new DateTime(2021, 8, 9), 5, 
                    "I did work experience at Borwells Ltd. I learnt industry standard programming (and practice) along " +
                    "with how both a software and cyber company operate day to day."),
                new RowClass("Networking ALevel Projects", "own project", "", new DateTime(2021, 10, 26), 26, 
                    "I have created and coded my own networking protocols following a star network topology with socket " +
                    "programming for both my ALevel and my personal projects."),
                new RowClass("Cyber Centurion Competition", "other", "", new DateTime(2021, 10, 22), 6, 
                    "I have competed in the Cyber Centurion run by the American Air Force Association."),
                new RowClass("(CADS) Cyber Apprenticeship Development Scheme", "course", "", new DateTime(2021, 9, 14), 12, 
                    "I am currently participating in CADS where I am learning about everything from reconnaissance and OSINT to interview " +
                    "techniques and CV development."),
                new RowClass("Frontend web developer", "work/placement project", "", new DateTime(2020, 1, 1), 50, 
                    "(Continuous) I am the front end web developer for the Malvern Cube. I also help with creating advertisements for " +
                    "their social media and employment adverts."),
                new RowClass("Created a C# webinar", "own project", "", new DateTime(2020, 10, 12), 2, 
                    "I created and presented a C# basics webinar for my peers. It has successfully improved their ability at coding in C# " +
                    "and I received positive feedback for it."),
                new RowClass("Created GitHub Basics presentation.", "own project", "", new DateTime(2021, 11, 8), 1, 
                    "I created and delivered a 'How to use GitHub' presentation. It successfully taught my peers how to use and utilise " +
                    "GitHub for their ALevel projects."),
                new RowClass("CyberFirst Futures", "summer school", "", new DateTime(2020, 8, 3), 10, "I participated in CyberFirst " +
                    "Futures delivered by the National Cyber Security Centre. Here I earned the CyberFirst Futures (SCQF Level 5) certificate"),
                new RowClass("Cyber Discovery", "other", "", new DateTime(2019, 1, 17), 75, "I participated in CyberStart Assess " +
                    "along with all the future rounds (including being invited to complete the SANS foundation). I practiced " +
                    "the fundamental Penetration Testing skills here."),
                new RowClass("Ran a Coding Club", "other", "", new DateTime(2019, 1, 7), 25, "I co-hosted a Coding Club teaching Python " +
                    "to Years 7 to 9."),
            };

        private static string Cyber2Data = "I thought that there would be no better way to creatively communicate how the impact of both CyberFirst Advanced and " +
            "the Work Experience at Collins Aerospace had developed my understanding than to utilise the basics of encryption " +
            "that I had learnt. I love a challenge, and as such I thought that decrypting this in the Linux Shell would be just that. Another solution " +
            "to my 'puzzle' is to read this through " +
            "GitHub on the burner account I created.\nWhen talking about each of the activities; CyberFirst Advanced was instrumental in teaching me the " +
            "intermediate areas of Cyber Security, along with how it is used, exploited, and how to fix this. " +
            "Collins Aerospace tought me a lot, from practical and quick programming, to industry standard networking and infrastructure. I was able to help " +
            "configure switches, a PXE server, and firewalls. Using Ansible to automate configuration and " +
            "python to aid in edge detection, were just a few of the activities I participated in.";


        private static string ReadMeData = $"To undo my encryption, XOR cyber2 with the key {Key}, and then flip every bit. " +
            "Should you be unable to in the Linux Shell, see https://github.com/agskfywh-jLb4Ai-8s-df209sd2ytv4-h7ky2fk";
       

        public static void Main() {
            Cyber1Handler();

            Console.WriteLine($"Cyber2 has {1000 - Cyber2Data.Length} remaining");
            for (int i = Cyber2Data.Length; i < 1000; i++) {
                Cyber2Data += " ";
            }

            byte[] cyber2;
            cyber2 = Cyber2Handler_BitFlip(ASCII.GetBytes(Cyber2Data));
            cyber2 = Cyber2Handler_XORKey(cyber2, ASCII.GetBytes(Key));


            File.WriteAllBytes(Cyber2Dir, cyber2);

            cyber2 = File.ReadAllBytes(Cyber2Dir);
            cyber2 = Cyber2Handler_XORKey(cyber2, ASCII.GetBytes(Key));
            cyber2 = Cyber2Handler_BitFlip(cyber2);
            File.WriteAllBytes(UndoneDir, cyber2);



            // ReadMe stuff
            Console.WriteLine($"ReadMe bytes remaining: {200 - ReadMeData.Length}");
            for (int i = 0; i < 200 - ReadMeData.Length; i++) {
                ReadMeData += " ";
            }
            File.WriteAllBytes(ReadMeDir, ASCII.GetBytes(ReadMeData));

            Console.ReadLine();
        }

        private static void Cyber1Handler() {
            // File Clears
            File.WriteAllText(Cyber1Dir, "");

            // File writing
            foreach (RowClass activity in Cyber1Data) {
                File.WriteAllBytes(Cyber1Dir, Encoding.ASCII.GetBytes((
                    File.ReadAllText(Cyber1Dir) + "\n" + activity.DataAsCSV()).Trim()));
            }

            // Byte Whitespacing
            byte[] f = File.ReadAllBytes(Cyber1Dir);
            string toAppend = "\nWhitespace Line,other,,0000-00-00,0,";
            string dataExpansion = "Whitespace ";
            int initialLength = f.Length + toAppend.Length;

            if (initialLength >= 2500) {
                Console.WriteLine($"Over byte limit by {f.Length + toAppend.Length - 2500}");
                Console.ReadLine();
                return;
            }

            for (int i = initialLength; i < 2500; i++) {
                toAppend += dataExpansion[i % dataExpansion.Length];
            }

            File.WriteAllBytes(Cyber1Dir, ASCII.GetBytes((File.ReadAllText(Cyber1Dir) + toAppend).Trim()));

            Console.WriteLine($"Cyber1 Success! {2500 - initialLength} bytes remaining.");
        }
    
        private static byte[] Cyber2Handler_BitFlip(byte[] input) {
            for (int i = 0; i < input.Length; i++) {
                input[i] ^= 255;
            }
            Console.WriteLine($"Cyber2 Success! {1000 - input.Length} remaining.");
            return input;

        }
    
        private static byte[] Cyber2Handler_XORKey(byte[] input, byte[] key) {
            for (int i = 0; i < input.Length; i++) {
                input[i] ^= key[i % key.Length];
            }
            Console.WriteLine($"Cyber2 Success! {1000 - input.Length} remaining.");
            return input;
        }
    
    }
}
