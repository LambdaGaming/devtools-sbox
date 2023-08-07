namespace Sandbox.Tools;

[Library( "tool_getmodelmat", Title = "Get Model/Material", Description = "Prints the model and material path of target entity." )]
public partial class GetModelMatTool : BaseTool
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
					Log.Info( ent.GetModelName() );
				}
			}
			else if ( Input.Pressed( "attack2" ) )
			{
				TraceResult tr = DoTrace();
				if ( tr.Hit && tr.Entity.IsValid() && tr.Entity is ModelEntity ent )
				{
					Log.Warning( "Material feature currently not supported." );
				}
			}
		}
	}
}
