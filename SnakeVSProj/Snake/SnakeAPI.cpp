#include "pch.h"
#include "SnakeAPI.h"
#include "Snake.h"


PLUGIN_API void* Snake_Create(CIntVector2 dir, int maxBodyPieceCount, CIntVector2* snakeBody)
{
    IntVector2* vec = (IntVector2*)snakeBody;
    IntVector2 newDir = IntVector2(dir.x, dir.y);
    return new Snake(newDir, maxBodyPieceCount,  vec);
}



PLUGIN_API void Snake_Destroy(void* snakePtr)
{
    Snake* snake = static_cast<Snake*>(snakePtr);

    if (snake != nullptr)
    {
        delete snake;
        snake = nullptr;
    }
}


PLUGIN_API int Snake_Expand(void* snakePtr)
{
    Snake* snake = static_cast<Snake*>(snakePtr);

    if (snake != nullptr)
    {
        return snake->Expand();
    }
    return 0;
}

PLUGIN_API void Snake_SetNewDirection(void* snakePtr, CIntVector2 newDir)
{

    Snake* snake = static_cast<Snake*>(snakePtr);
    IntVector2 newDirection;
    newDirection.x = newDir.x;
    newDirection.y = newDir.y;
    if (snake != nullptr)
    {
        return snake->SetNewDirection(newDirection);
        
    }
}

PLUGIN_API void Snake_UpdateBodyPosition(void* snakePtr)
{
    Snake* snake = static_cast<Snake*>(snakePtr);

    if (snake != nullptr)
    {
        snake->UpdateBodyPosition();
    }
}

PLUGIN_API bool Snake_CheckForCollision(void* snakePtr, CIntVector2 index)
{
    Snake* snake = static_cast<Snake*>(snakePtr);

    if (snake != nullptr)
    {
        IntVector2 newindex = IntVector2(index.x, index.y);
       return  snake->CheckForCollision(newindex);
    }
    return false;
}

PLUGIN_API bool Snake_CheckForEndCollision(void* snakePtr)
{
    Snake* snake = static_cast<Snake*>(snakePtr);

    if (snake != nullptr)
    {
        return  snake->CheckForEndCollision();
    }
    return false;
}





