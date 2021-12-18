using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Manatea.SceneManagement
{
    [Serializable]
    public struct SceneReference
    {
        [SerializeField]
        private string m_Guid;
        public string Guid
        {
            get => m_Guid;
            set => m_Guid = value;
        }
    }
}
