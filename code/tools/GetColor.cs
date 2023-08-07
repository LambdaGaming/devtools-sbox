namespace Sandbox.Tools;

[Library( "tool_getcolor", Title = "Get Color", Description = "Prints color of target entity." )]
public partial class GetColorTool : BaseTool
{
	public override void Simulate()
	{
		if ( !Game.IsServer ) return;

		using ( Prediction.Off() )
		{
			if ( Input.Pressed( "attack1" ) )
			{
				TraceResult tr = DoTrace();
				if ( tr.Hit && tr.Entity.IsValid() && tr.Entity is ModelEntity ent )
				{
					Log.Info( ent.RenderColor.Rgba );
				}
			}
		}
	}
}
