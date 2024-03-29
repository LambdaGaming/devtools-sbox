﻿namespace Sandbox.Tools;

[Library( "tool_getposlocal", Title = "Get Pos Relative To Trace Entity", Description = "Prints position of your trace relative to the entity that the trace hit." )]
public partial class GetPosLocalTool : BaseTool
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
					Log.Info( tr.Entity.Transform.PointToLocal( tr.HitPosition ) );
				}
			}
		}
	}
}
