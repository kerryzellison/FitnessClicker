namespace Resources{
    [System.Serializable]
    public struct ResourceAmount {
        public int amount;
        public Resource resource;

        public override string ToString() {
        return $"{this.amount}";
        }

        public bool IsAffordable => this.resource.Owned >= this.amount;
		
        public void Create() {
            this.resource.Owned += this.amount;
        }
		
        public void Consume() {
            this.resource.Owned -= this.amount;
        }
    }
}
