using System;
using LiteNetLib.Utils;

namespace Game.Network.Players {
    public class Player : IEncodable {

        private int id;
        private string name;
        private bool ready;

        #region Constructors

        public Player() {
            id = 0;
            name = "";
            ready = false;
        }

        public Player(int playerID, string playerName) {
            this.id = playerID;
            this.name = playerName;
            this.ready = false;
        }

        public Player(int playerID) {
            this.id = playerID;
            this.name = "";
            this.ready = false;
        }

        #endregion

        #region Accessors

        public int ID {
            get { return id; }
        }

        public string Name {
            get { return name; }
        }

        public bool Ready {
            get { return ready; }
        }

        public void SetID(int identifier) {
            this.id = identifier;
        }

        public void SetUsername(string name) {
            this.name = name;
        }

        public void SetReady(bool value) {
            this.ready = value;
        }

        #endregion

        public void Serialize(NetDataWriter writer) {
            writer.Put(id);
            writer.Put(name);
            writer.Put(ready);
        }

        public void Deserialize(NetDataReader reader) {
            id = reader.GetInt();
            name = reader.GetString(50);
            ready = reader.GetBool();
        }

        public override bool Equals(object obj) {
            if (!(obj is Player))
                return false;
            return ((Player)obj).id == this.id;
        }

        public override int GetHashCode() {
            return id;
        }

        public override string ToString() {
            return "[" + id + "] " + name + ((ready) ? " (ready) " : "(not ready)");
        }
    }
}