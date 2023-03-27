using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeGlue : IDisposable
{
    public SnakeGlue(IntVector2 movementDirection, int maxBodyPieceCount,  IntVector2[] snakebody)
    {
        Impl = Snake_Create(movementDirection, maxBodyPieceCount, snakebody);
    }


    public void Snake_Create()
    {
        Snake_Create(Impl);
    }



    public void Dispose()
    {
        CleanUp();

        GC.SuppressFinalize(this);
    }


    ~SnakeGlue()
    {
        CleanUp();
    }

    private void CleanUp()
    {
        if (Impl != IntPtr.Zero)
        {
            Snake_Destroy(Impl);
            Impl = IntPtr.Zero;
        }
    }
    public int Expand()
    {
      return Snake_Expand(Impl);
    }
    public void SetNewDirection(IntVector2 newdir)
    {
        Snake_SetNewDirection(Impl, newdir);
    }

    public void UpdateBodyPosition(IntVector2[] SnakeBody)
    {
       Snake_UpdateBodyPosition(Impl, SnakeBody);
    }


    public bool CheckForCollision(IntVector2 appleindex)
    {
        return Snake_CheckForCollision(Impl, appleindex);
    } 
    public bool CheckForEndCollision()
    {
        return Snake_CheckForEndCollision(Impl);
    }

    public IntPtr Impl { get; private set; }

    [DllImport("SnakePlugin")]
    static extern IntPtr Snake_Create(IntVector2 movementDirection, int maxBodyPieceCount, [MarshalAs(UnmanagedType.SafeArray)] IntVector2[] snakebody);

    [DllImport("SnakePlugin")]
    static extern void Snake_Destroy(IntPtr ptr);
    [DllImport("SnakePlugin")]
    static extern void Snake_Create(IntPtr ptr);

    [DllImport("SnakePlugin")]
    static extern int Snake_Expand(IntPtr ptr);

    [DllImport("SnakePlugin")]
    static extern void Snake_SetNewDirection(IntPtr ptr, IntVector2 newDir);
    [DllImport("SnakePlugin")]
    static extern void Snake_UpdateBodyPosition(IntPtr ptr, IntVector2[] SnakeBody);
    [DllImport("SnakePlugin")]
    static extern bool Snake_CheckForCollision(IntPtr ptr, IntVector2 appleIndex);
    [DllImport("SnakePlugin")]
    static extern bool Snake_CheckForEndCollision(IntPtr ptr);
}