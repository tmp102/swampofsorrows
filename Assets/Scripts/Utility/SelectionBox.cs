using System;
using UnityEngine;

[Serializable]
public struct SelectionBox
{
    private Rect m_Rect;
    private float m_Angle;

    public Vector2 position
    {
        get
        {
            return m_Rect.position;
        }
        set
        {
            m_Rect.position = value;
        }
    }

    private Rect rect
    {
        get
        {
            return m_Rect;
        }
        set
        {
            m_Rect = value;
        }
    }

    public Vector2 size
    {
        get
        {
            return m_Rect.size;
        }
        set
        {
            m_Rect.size = value;
        }
    }

    public float angle
    {
        get
        {
            return m_Angle;
        }
        set
        {
            m_Angle = value;
        }
    }

    public SelectionBox(Rect rect, float angle = 0.0f)
    {
        m_Rect = rect;
        m_Angle = angle;
    }

    public bool Contains(Vector2 point)
    {
        point = position + (Vector2)(Quaternion.Euler(0.0f, 0.0f, angle) * (point - position));
        return rect.Contains(point);
    }
}
