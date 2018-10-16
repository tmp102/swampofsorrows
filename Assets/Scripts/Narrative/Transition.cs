using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Narrative
{
    [CreateAssetMenu(fileName = "New Transition", menuName = "Transitions/Transition")]
    public class Transition : ScriptableObject, ISelectable
    {
        [SerializeField]
        private State m_SourceState;

        [SerializeField]
        private State m_DestinationState;

        public State sourceState
        {
            get
            {
                return m_SourceState;
            }
            set
            {
                m_SourceState = value;
            }
        }

        public State destinationState
        {
            get
            {
                return m_DestinationState;
            }
            set
            {
                m_DestinationState = value;
            }
        }

        public SelectionBox selectionBox
        {
            get
            {
                Vector2 startPosition = sourceState.rect.center + new Vector2(sourceState.rect.size.x / 2, 0.0f);
                Vector2 endPosition = destinationState.rect.center - new Vector2(destinationState.rect.size.x / 2, 0.0f);

                Vector2 centerPoint = startPosition + (endPosition - startPosition) / 2;

                Rect rect = new Rect(centerPoint.x - 10.0f, centerPoint.y - 10.0f, 20.0f, 20.0f);

                return new SelectionBox(rect);
            }
        }

        public virtual void DisplayOn(ITransitionDisplay display)
        {
            display.description = "Next...";
        }

        public virtual void Draw(bool selected = false)
        {
            Color color = Color.white;
            if (selected)
            {
                color = new Color(0.42f, 0.70f, 1.00f);
            }
            else
            {
                color = Color.white;
            }
            DrawLine(sourceState, destinationState, color, 4.25f);
        }

        private static void DrawLine(State sourceState, State destinationState, Color color, float width)
        {
            Vector2 startPosition = sourceState.rect.center + new Vector2(sourceState.rect.size.x / 2, 0.0f);
            Vector2 endPosition = destinationState.rect.center - new Vector2(destinationState.rect.size.x / 2, 0.0f);
            Vector2 startTangent = startPosition + Vector2.right * 75.0f;
            Vector2 endTangent = endPosition + Vector2.left * 75.0f;

            Vector2 centerPoint = startPosition + (endPosition - startPosition) / 2;

            Vector3[] points = new Vector3[4];
            points[0] = centerPoint + Vector2.up * width + Vector2.left * width;
            points[1] = centerPoint + Vector2.up * width + Vector2.right * width;
            points[2] = centerPoint + Vector2.down * width + Vector2.right * width;
            points[3] = centerPoint + Vector2.down * width + Vector2.left * width;

            Handles.DrawBezier(startPosition, endPosition, startTangent, endTangent, color, null, width);
            Color c = Handles.color;
            Handles.color = color;
            Handles.DrawAAConvexPolygon(points);
            Handles.color = c;
        }
    }
}
