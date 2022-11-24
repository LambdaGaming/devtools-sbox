namespace Sandbox.Tools
{
	[Library( "tool_getnameclass", Title = "Get Name/Class", Description = "Prints the name and class of the target entity." )]
	public partial class GetNameClassTool : BaseTool
	{
		public override void Simulate()
		{
			if ( !Host.IsServer ) return;

			using ( Prediction.Off() )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					TraceResult tr = DoTrace();
					if ( tr.Hit && tr.Entity.IsValid() )
					{
						Log.Info( tr.Entity.Name );
					}
				}
				else if ( Input.Pressed( InputButton.SecondaryAttack ) )
				{
					TraceResult tr = DoTrace();
					if ( tr.Hit && tr.Entity.IsValid() )
					{
						Log.Info( tr.Entity.ClassName );
					}
				}
			}
		}
	}
}
