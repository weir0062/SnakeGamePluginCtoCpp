#pragma once


#ifdef SNAKE_EXPORTS 
#define PLUGIN_API __declspec(dllexport)
#else
#define PLUGIN_API __declspec(dllimport)
#endif

extern "C"
{
    PLUGIN_API void* Snake_Create(CIntVector2 dirKO, int maxBodyPieceCount, CIntVector2* snakeBody);
    PLUGIN_API void Snake_Destroy(void* snakePtr);
    PLUGIN_API int Snake_Expand(void* snakePtr);
    PLUGIN_API void Snake_SetNewDirection(void* snakePtr, CIntVector2 newDir);
    PLUGIN_API void Snake_UpdateBodyPosition(void* snakePtr);
    PLUGIN_API bool Snake_CheckForCollision(void* snakePtr, CIntVector2 index);
    PLUGIN_API bool Snake_CheckForEndCollision(void* snakePtr);
    
}


