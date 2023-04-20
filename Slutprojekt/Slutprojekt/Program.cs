using Raylib_cs;


Raylib.InitWindow(800, 600, "Xman");
Raylib.SetTargetFPS(60);


Random generetor = new Random(); //is used to generate a random number


Texture2D backgroundy = Raylib.LoadTexture("slutback.png"); // loads an image file as a texture in a game
Texture2D menyy = Raylib.LoadTexture("meny.png");
Texture2D maincharacter = Raylib.LoadTexture("yoshiii.png");
Texture2D goomba = Raylib.LoadTexture("lulu.png");
Texture2D bullet = Raylib.LoadTexture("bullet.png");


var characters = new[] {  //to make it easier to change  characters width & height and making it easier to change from here 
new { name = "maincharacter", width = 100, height = 100 },
new { name = "goomba", width = 20, height = 150 },
new { name = "bullety", width = 60, height = 60 }
};


string scene = "second";  //variable to to store the current scene
float fast = 5;
Rectangle mainy = new Rectangle(0, 454, characters[0].width, characters[0].height); //rectangle to represt the images 
Rectangle goomby = new Rectangle(700, 438, characters[1].width, characters[1].height);
Rectangle bullety = new Rectangle(-100, -100, characters[2].width, characters[2].height);
Rectangle bulletCollision = new Rectangle(
bullety.x - 50, bullety.y - 50, bullet.width - 100, bullet.height); //rectangle to make collison between the bullet and goomba simpler
float bulletSpeed = 10;
bool bulletVisible = false;

void Loby() //method that makes a code into a variable which could be used later on in the code by only using  a single word
{
    while (mainy.x > 770 || mainy.x < -20)
    {
        if (mainy.x > 770)
        {
            mainy.x = 0;
        }
        if (mainy.x < -20)
        {
            mainy.x = 750;
        }
    }
}

void Boby()
{

    if (goomby.x < -20)
    {
        goomby.x = 750;
    }

}


while (!Raylib.WindowShouldClose()) //a loop that will continue running until the window is closed 
{

    if (scene == "first") // if the scene is first the things inside the paragraph are supposed to happen
    {

        if (bulletVisible)  // makes the bullet visible when space is pressed 
        {
            bullety.x += bulletSpeed; //the bullet moves horizontally to the right 
            bulletCollision.x = bullety.x; //makes the collsions x the same as the bullet
            bulletCollision.y = bullety.y;  //makes the collsions y the same as the bullet
        }


        goomby.x -= 5; //makes the goomba character move horizontally to the left 

        Boby(); //these two are the methods used earlier in the code
        Loby();


        if (Raylib.CheckCollisionRecs(goomby, mainy)) //this checks the collsion between the first and second character meaning if they touch eachother
        {
            scene = "third";  //if goomba and mainy collides then switch the scene to third
            goomby.x = 700;     //if goomba and mainy collides then it resets goomba to the start postion to avoid a loop/bug
            bulletVisible = false;  // the bullets resets/becomes invisible 
            bullety.x = -100; //bullets x and y position resets 
            bullety.y = -100;
            bulletCollision.x = bullety.x - 50;  //the collsion rectangle resets too
            bulletCollision.y = bullety.y - 50;
            mainy.x = 50; //resets mainy to the start postion to avoid a loop/bug

        }

        if (Raylib.CheckCollisionRecs(goomby, bullety)) //this checks the collsion between the bullet and goomba 
        {
            scene = "fourth"; //if so switches to scene three
            goomby.x = 700; //these code lines below are explained earlier
            bulletVisible = false;
            bullety.x = -100;
            bullety.y = -100;
            bulletCollision.x = bullety.x - 50;
            bulletCollision.y = bullety.y - 50;
            mainy.x = 50; 

        }


        if (bullety.x > Raylib.GetScreenWidth())  //if the bullet goes too much horizontally that it gets out the screen it becomes invisible
        {
            bulletVisible = false;
        }


        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) //if the certain key is pressed mainy is moved to the right or left depending on the key
        {
            mainy.x += fast;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            mainy.x -= fast;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE)) //if the space button is pressed the bullet fires
        {
            if (!bulletVisible) //if the bullet isnt visible the bullet changes the postiion according to mainy 
            {
                bullety.x = mainy.x + mainy.width;
                bullety.y = mainy.y + (mainy.height / 2) - (bullet.height / 2);
                bulletVisible = true; //when it fires it becomes visible
            }
        }

    }



    string[] scenes = { "second", "third", "fourth" }; //a string array named scene with the values "second, third and fourth"

    for (int i = 0; i < scenes.Length; i++) //a for loop that works if the scenes value is bigger than 0  
    {
        if (scene == scenes[i])   //checks if the value of the string variable scene is equal to the value of the element at index i in the scenes array.
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER)) //if the Enter button is pressed 
            {
                scene = "first"; //the scene changes to the first 
            }
        }
    }









    Raylib.BeginDrawing();  
    Raylib.ClearBackground(Color.WHITE);




    if (scene == "first") //if the scene is the first then the code below is gonna work 
    {
        Raylib.DrawTexture(backgroundy, -50, -50, Color.WHITE);
        Raylib.DrawTexture(maincharacter, (int)mainy.x, (int)mainy.y, Color.WHITE);
        Raylib.DrawTexture(goomba, (int)goomby.x, (int)goomby.y, Color.WHITE);
        Raylib.DrawTexture(bullet, (int)bullety.x, (int)goomby.y + 80, Color.WHITE);
    }




    if (scene == "second") //if the scene is the second then the code below is gonna work 
    {
        Raylib.DrawTexture(menyy, 0, 0, Color.WHITE);
        Raylib.DrawText("WELCOME TO SHOOT GOOMBA", 100, 250, 40, Color.BLACK);
        Raylib.DrawText("Use A and D to move and SPACE to shoot", 100, 450, 25, Color.BLACK);
        Raylib.DrawText("Copyright © Nami", 5, 575, 20, Color.BLACK);
    }


    if (scene == "third") //if the scene is the third then the code below is gonna work 
    {
        Raylib.DrawTexture(menyy, 0, 0, Color.WHITE);
        Raylib.DrawText("YOU DIED PRESS ENTER TO PLAY AGAIN", 50, 250, 25, Color.BLACK);
        Raylib.DrawText("Copyright © Nami", 5, 575, 20, Color.BLACK);
    }


    if (scene == "fourth") //if the scene is the fourth then the code below is gonna work 
    {
        Raylib.DrawTexture(menyy, 0, 0, Color.WHITE);
        Raylib.DrawText("YOU WON PRESS ENTER TO PLAY AGAIN", 50, 250, 25, Color.BLACK);
        Raylib.DrawText("Copyright © Nami", 5, 575, 20, Color.BLACK);
    }






    Raylib.EndDrawing();


}



