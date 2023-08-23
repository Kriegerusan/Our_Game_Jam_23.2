using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Text", menuName = "Text Area")]
public class Text_Object : ScriptableObject
{
    [SerializeField][TextArea(5,25)] private string text;
}
