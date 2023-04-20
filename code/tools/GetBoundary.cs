namespace Sandbox.Tools
{
	[Library( "tool_getboundary", Title = "Get Boundary", Description = "Spawns 2 blocks that you can manually place to create a boundary, and prints the upper and lower values of that boundary." )]
	public partial class GetBoundaryTool : BaseTool
	{
		[Net]
		public ModelEntity Node1 { get; set; }

		[Net]
		public ModelEntity Node2 { get; set; }

		bool NodesValid() => Node1.IsValid() && Node2.IsValid();

		public override void Simulate()
		{
			if ( Game.IsClient )
			{
				if ( NodesValid() )
				{
					DebugOverlay.Box( Node1.Position, Node2.Position, Color.Green );
				}
			}
			else if ( Game.IsServer )
			{
				using ( Prediction.Off() )
				{
					if ( Input.Pressed( "attack1" ) && !NodesValid() )
					{
						TraceResult tr = DoTrace();
						Node1 = new ModelEntity();
						Node1.SetModel( "models/maya_testcube_100.vmdl" );
						Node1.Position = tr.HitPosition;
						Node1.Scale = 0.1f;
						Node1.SetupPhysicsFromModel( PhysicsMotionType.Dynamic );
						Node2 = new ModelEntity();
						Node2.SetModel( "models/maya_testcube_100.vmdl" );
						Node2.Position = tr.HitPosition + new Vector3( 0, 0, 10 );
						Node2.Scale = 0.1f;
						Node2.SetupPhysicsFromModel( PhysicsMotionType.Dynamic );
					}
					else if ( Input.Pressed( "attack2" ) && NodesValid() )
					{
						Node1.Delete();
						Node2.Delete();
					}
					else if ( Input.Pressed( "reload" ) && NodesValid() )
					{
						Vector3 upper;
						Vector3 lower;
						if ( Node1.Position.z > Node2.Position.z )
						{
							upper = Node1.Position;
							lower = Node2.Position;
						}
						else
						{
							upper = Node2.Position;
							lower = Node1.Position;
						}
						Log.Info( $"Upper: {upper}" );
						Log.Info( $"Lower: {lower}" );
					}
				}
			}
		}
	}
}
