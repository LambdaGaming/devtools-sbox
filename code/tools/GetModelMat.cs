namespace Sandbox.Tools
{
	[Library( "tool_getmodelmat", Title = "Get Model/Material", Description = "Prints the model and material path of target entity." )]
	public partial class GetModelMatTool : BaseTool
	{
		public override void Simulate()
		{
			if ( !Host.IsServer ) return;

			using ( Prediction.Off() )
			{
				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					TraceResult tr = DoTrace();
					if ( tr.Hit && tr.Entity.IsValid() && tr.Entity is ModelEntity ent )
					{
						Log.Info( ent.GetModelName() );
					}
				}
				else if ( Input.Pressed( InputButton.SecondaryAttack ) )
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
}
