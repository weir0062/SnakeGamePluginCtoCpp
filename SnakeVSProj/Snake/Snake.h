#pragma once


class Snake
{
public:
    Snake(IntVector2 dir,  int maxBodyPieceCount, IntVector2* bodypieces);

    virtual ~Snake();

    bool CheckForEndCollision();
    bool CheckForCollision(IntVector2 appleIndex);
    int Expand();
    void SetNewDirection(IntVector2 newDirection);
    void UpdateBodyPosition();
private:

    float m_AccumulatedTime;
    float m_UpdateRate;
    int m_BodyPieceCount;
    int m_MaxBodyPieceCount;
    IntVector2 m_MovementDirection;
    IntVector2* m_SnakeBody;

};

