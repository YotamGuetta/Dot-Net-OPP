using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogics
{
    struct Player //struct or class?
    {
        private string m_playerName; // check if needed
        private char m_symbol;
        private int m_score;

        public Player(char i_symbol, string i_playerName)
        {
            m_symbol = i_symbol;
            m_playerName = i_playerName;
            m_score = 0;
        }

        public char Symbol 
        {
            get { return m_symbol; } 
        }

        public string Name
        {
            get { return m_playerName; }
        }

        public int Score 
        {
            get { return m_score; }
            set { m_score = value; } 
        }
    }
}
