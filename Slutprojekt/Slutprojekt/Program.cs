using Raylib_cs;


public class Program {
    static int AddNumbers(int x, int y) {
        return x + y;
    }


   


    static void Main(string[] method) {
        Raylib.InitWindow(800, 600, "Xman");
        Raylib.SetTargetFPS(60);


        Random generetor = new Random();




        int result = AddNumbers(2, 3);
        // The result variable will have the value 5


        Texture2D backgroundy = Raylib.LoadTexture("slutback.png");
        Texture2D menyy = Raylib.LoadTexture("meny.png");
        Texture2D maincharacter = Raylib.LoadTexture("yoshiii.png");
        Texture2D goomba = Raylib.LoadTexture("lulu.png");
        Texture2D bullet = Raylib.LoadTexture("bullet.png");


        var characters = new[] {
            new { name = "maincharacter", width = 100, height = 100 },
            new { name = "goomba", width = 150, height = 150 },
            new { name = "bullet", width = 50, height = 50 }


        };


        string scene = "second";
        float fast = 5;
        Rectangle mainy = new Rectangle(0, 454, characters[0].width, characters[0].height);
        Rectangle goomby = new Rectangle(700, 438, characters[1].width, characters[1].height);
        Rectangle bullety = new Rectangle(-100, -100, characters[2].width, characters[2].height);
        Rectangle bulletCollision = new Rectangle(
        bullety.x - 50, bullety.y -50, bullet.width -50, bullet.height);
        float bulletSpeed = 10;
        bool bulletVisible = false;


        while (!Raylib.WindowShouldClose()) {
            if (scene == "first") {

                if (bulletVisible) {
                    bullety.x += bulletSpeed;
                    bulletCollision.x = bullety.x ;
                    bulletCollision.y = bullety.y ;
                }


                goomby.x -= 5;




                if (Raylib.CheckCollisionRecs(goomby, mainy)) {
                    scene = "third";
                    goomby.x = 700;
                    bulletVisible = false;
                    bullety.x = -100;
                    bullety.y = -100;
                    bulletCollision.x = bullety.x - 50; 
                    bulletCollision.y = bullety.y -50;

                }


                if (bullety.x > Raylib.GetScreenWidth()) {
                    bulletVisible = false;
                }






           
               


                if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) {
                    mainy.x += fast;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) {
                    mainy.x -= fast;
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) {
                    if (!bulletVisible) {
                        bullety.x = mainy.x + mainy.width ;
                        bullety.y = mainy.y + (mainy.height / 2) - (bullet.height / 2);
                        bulletVisible = true;
                    }
                }


               
           
            }


            if (scene == "second") {
                if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER)) {
                    scene = "first";
                }
            }


            while (mainy.x > 770 || mainy.x < -20) {
                if (mainy.x > 770) {
                    mainy.x = 0;
                }
                if (mainy.x < -20) {
                    mainy.x = 750;
                }
            }

            if (scene == "third") {
                if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER)) {
                    scene = "first";
                }
            }


        


            Raylib.BeginDrawing();




            Raylib.ClearBackground(Color.WHITE);










            if (scene =="first") {
               Raylib.DrawTexture(backgroundy, -50, -50, Color.WHITE);
                  Raylib.DrawTexture(maincharacter, (int)mainy.x, (int)mainy.y, Color.WHITE);
                Raylib.DrawTexture(goomba, (int)goomby.x, (int)goomby.y,Color.WHITE );
                Raylib.DrawTexture(bullet, (int)bullety.x, (int)goomby.y + 80,Color.WHITE);
            }




            if (scene == "second") {
            Raylib.DrawTexture(menyy, 0, 0, Color.WHITE);
            Raylib.DrawText("WELCOME TO SHOOT GOOMBA", 100, 250, 40, Color.BLACK);
            Raylib.DrawText("Use A and D to move and SPACE to shoot", 100, 450, 25, Color.BLACK);
            Raylib.DrawText("Copyright © Nami", 5, 575, 20, Color.BLACK);
          }


          if (scene == "third") {
            Raylib.DrawTexture(menyy, 0, 0, Color.WHITE);
            Raylib.DrawText("You died PRESS ENTER TO PLAY AGAIN", 50, 250, 25, Color.BLACK);
            Raylib.DrawText("Copyright © Nami", 5, 575, 20, Color.BLACK);
          }


          


        
            Raylib.EndDrawing(); 


        }
    }
}

