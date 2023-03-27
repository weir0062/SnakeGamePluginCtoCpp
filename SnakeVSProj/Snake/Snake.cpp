#include "pch.h"
#include "Snake.h"


Snake::Snake(IntVector2 dir, int maxBodyPieceCount, IntVector2* bodypieces)
{

    m_UpdateRate = 0.3f;
    m_AccumulatedTime = m_UpdateRate;

    m_MaxBodyPieceCount = maxBodyPieceCount;

    m_BodyPieceCount = 1;

    m_SnakeBody = bodypieces;

    //Setting initial head position
    m_SnakeBody[0] = IntVector2(0, 0);

    m_MovementDirection = dir;
}

Snake::~Snake()
{

}


bool Snake::CheckForEndCollision()
{
    bool collision = false;

    
        for (int i= 1; i < m_BodyPieceCount; i++)
        {
            
            collision = m_SnakeBody[0] == m_SnakeBody[i];
            if (collision == true)
            {
                return collision;
            }
        }

    
    return collision;
}
bool Snake::CheckForCollision(IntVector2 appleIndex)
{
    bool collision = false;
    if (m_BodyPieceCount >= m_MaxBodyPieceCount)
        return false;


    for (int i = 0; i < m_MaxBodyPieceCount; i++)
    {

        collision = appleIndex == m_SnakeBody[i];
        if (collision == true)
        {
            return collision;
        }

    }
    return collision;
}

int Snake::Expand()
{
    IntVector2 lastCellIndex = IntVector2(0, 0);
    if (m_BodyPieceCount > 1)
    {
        lastCellIndex = m_SnakeBody[m_BodyPieceCount - 1];
    }
    else
    {
        lastCellIndex = m_SnakeBody[0];
    }

    lastCellIndex += m_MovementDirection * -1;

    m_SnakeBody[m_BodyPieceCount] = lastCellIndex;

    m_BodyPieceCount++;

    return m_BodyPieceCount;
}

void Snake::SetNewDirection(IntVector2 newDirection)
{
    if (m_MovementDirection != newDirection)
    {
        if (m_BodyPieceCount > 1 && (m_MovementDirection * -1) == newDirection)
        {
            return;
        }
        m_MovementDirection = newDirection;
    }
}

void Snake::UpdateBodyPosition()
{
    IntVector2 index = m_SnakeBody[0];
    IntVector2 newIndex = index + m_MovementDirection;
    // Set new head position
    m_SnakeBody[0] = newIndex;
    // Update remaining body pieces
    for (int i = 1; i < m_BodyPieceCount; i++)
    {
        // Save current body position
        IntVector2 bodyIndex = m_SnakeBody[i];
        // Assign previous body position to the next cell
        m_SnakeBody[i] = index;
        // Pass position to the next body piece
        index = bodyIndex;
    }

    for (int i = 0; i < m_BodyPieceCount; i++)
    {
        if (m_SnakeBody[i].y < 0)
        {
            m_SnakeBody[i].y = 20;
        }
        else if (m_SnakeBody[i].y >= 20)
        {
            m_SnakeBody[i].y = 0;
        }
        if (m_SnakeBody[i].x < 0)
        {
            m_SnakeBody[i].x = 20;
        }
        else if (m_SnakeBody[i].x >= 20)
        {
            m_SnakeBody[i].x = 0;
        }
    }


}
