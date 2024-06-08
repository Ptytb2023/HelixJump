namespace Inputs
{
	public interface IInput
	{
		public bool Enable { get; set; }
		public void SetActive(bool value);
	}
}