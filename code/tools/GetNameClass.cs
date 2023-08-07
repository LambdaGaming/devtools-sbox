namespace Sandbox.Tools;

[Library( "tool_getnameclass", Title = "Get Name/Class", Description = "Prints the name and class of the target entity." )]
public partial class GetNameClassTool : BaseTool
{
	public override void Simulate()
	{
		if ( !Game.IsServer ) return;

		using ( Prediction.Off() )
		{
			if ( Input.Pressed( "attack1" ) )
			{
				TraceResult tr = DoTrace();
				if ( tr.Hit && tr.Entity.IsValid() )
				{
					Log.Info( tr.Entity.Name );
				}
			}
			else if ( Input.Pressed( "attack2" ) )
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
