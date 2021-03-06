//  Project  : ACTORS
//  Contacts : Pixeye - ask@pixeye.games


namespace Pixeye
{
	public class ProcessingActorsRemove : ProcessingBase
	{
 


		public Group<ComponentRelease> groupRelease;


		public ProcessingActorsRemove()
		{
			groupRelease.Add += entity => {
				ComponentObject cObject;


				if (entity.Get(out cObject))
				{
					var mono = cObject.transform.GetComponent<MonoEntity>();
					if (mono != null)
					{
						mono.Release();
						return;
					}

					cObject.transform.gameObject.Release(cObject.poolType);
				}

				Release(entity);
			};
		}

		void Release(int entity)
		{
			int len = Storage.all.Count;
			for (int j = 0; j < len; j++)
			{
				Storage.all[j].Remove(entity, false);
			}

			Tags.Clear(entity);
			ProcessingEntities.prevID.Push(entity);
		}

		 
	}

	 
}