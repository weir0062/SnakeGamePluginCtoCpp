using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Snake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        m_SnakeBody = new IntVector2[10];
        snakeGlue = new SnakeGlue(new IntVector2(0, 0), 10, m_SnakeBody);

        m_BodyPieceCount = 1;
        m_AccumulatedTime = 0;
        m_UpdateRate = 0.3f;

       // snakeGlue.Snake_Create();
    }

    void OnDestroy()
    {
        if (snakeGlue != null)
        {
            snakeGlue.Dispose();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Playing)
        {
            HandleInput();
            m_AccumulatedTime += Time.deltaTime;
            if (m_AccumulatedTime >= m_UpdateRate)
            {
                m_AccumulatedTime = 0.0f;

                snakeGlue.UpdateBodyPosition(m_SnakeBody);

                if (snakeGlue.CheckForCollision(Grid.Instance.GetAppleIndex()))
                {
                    m_BodyPieceCount = snakeGlue.Expand();

                    Grid.Instance.SpawnApple(m_SnakeBody);

                    //Speed increase by 20%
                    m_UpdateRate *= 0.8f;
                }

                if (snakeGlue.CheckForEndCollision())
                {
                    Playing = false;
                    snakeGlue.SetNewDirection(new IntVector2(0, 0));
                }

                Grid.Instance.DrawSnake(m_SnakeBody, m_BodyPieceCount);
            }
        }
    }

    void HandleInput()
    {
        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            snakeGlue.SetNewDirection(new IntVector2(0, 1));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            snakeGlue.SetNewDirection(new IntVector2(0, -1));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            snakeGlue.SetNewDirection(new IntVector2(1, 0));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            snakeGlue.SetNewDirection(new IntVector2(-1, 0));
        }
        
    }

    float m_AccumulatedTime;
    float m_UpdateRate;
    int m_BodyPieceCount;
    IntVector2[] m_SnakeBody;
    SnakeGlue snakeGlue;
    bool Playing = true;
}



























/*
public class Snake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {*//*
        m_UpdateRate = 0.3f;
        m_AccumulatedTime = m_UpdateRate;
      
        m_MaxBodyPieceCount = 10;
       
        m_BodyPieceCount = 1;

        m_SnakeBody = new IntVector2[m_MaxBodyPieceCount];

        //Setting initial head position
        m_SnakeBody[0] = new IntVector2(0, 0);

        m_MovementDirection = new IntVector2(0, 0);*//*
        snakeGlue = new SnakeGlue(new IntVector2(0, 0), 10, m_SnakeBody[0]);


        snakeGlue.Snake_Create();
    }

    void OnDestroy()
    {
        //Dispose of IDisposible classes here
    }

    void SetNewDirection(IntVector2 newDirection)
    {
       *//* if (m_MovementDirection != newDirection)
        {
            m_MovementDirection = newDirection;
        }*//*

        snakeGlue.SetNewDirection(newDirection);
    }

    void UpdateBodyPosition()
    {
        *//*    IntVector2 index = m_SnakeBody[0];
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
            }*//*
        snakeGlue.UpdateBodyPosition();
    }

    bool CheckForCollision(IntVector2 appleIndex)
    {
        if (m_BodyPieceCount >= m_MaxBodyPieceCount)
            return false;

        return appleIndex == m_SnakeBody[0];
    }

    int Expand()
    {
       *//* IntVector2 lastCellIndex = new IntVector2(0, 0);
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

        return m_BodyPieceCount;*//*

        return snakeGlue.Expand();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();

        m_AccumulatedTime += Time.deltaTime;
        if(m_AccumulatedTime >= m_UpdateRate)
        {
            m_AccumulatedTime = 0.0f;
        
            UpdateBodyPosition();
           
            if (CheckForCollision(Grid.Instance.GetAppleIndex()))
            {
                m_BodyPieceCount = Expand();
                
                Grid.Instance.SpawnApple();

                //Speed increase by 20%
                m_UpdateRate *= 0.8f;
            }

            Grid.Instance.DrawSnake(m_SnakeBody, m_BodyPieceCount);
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetNewDirection(new IntVector2(0, 1));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetNewDirection(new IntVector2(0, -1));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetNewDirection(new IntVector2(1, 0));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetNewDirection(new IntVector2(-1, 0));
        }
    }

    float m_AccumulatedTime;
    float m_UpdateRate;
    int m_BodyPieceCount;
    int m_MaxBodyPieceCount;
    IntVector2 m_MovementDirection;
    IntVector2[] m_SnakeBody;

    SnakeGlue snakeGlue;

}
*/