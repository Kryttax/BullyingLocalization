﻿using UnityEngine;
using System.Collections;

namespace Isometra.Sequences {
	public class GameEventInterpreter : ISequenceInterpreter
	{

		private bool launched = false;
		private bool finished = false;
		private SequenceNode node;
		private bool waitTillEventFinished;

		public bool CanHandle(SequenceNode node)
		{
			return node!= null && node.Content != null && node.Content is IGameEvent;
		}

		public void UseNode(SequenceNode node){
			this.node = node;
		}

		public bool HasFinishedInterpretation()
		{
			return finished;
		}

		public SequenceNode NextNode()
		{
			return (this.node.Childs.Length>0)?this.node.Childs[0]:null;
		}

		public void EventHappened(IGameEvent ge)
		{
			Debug.Log ("Something happened: " + ge.Name);
			if(waitTillEventFinished)
				if(ge.Name.ToLower() == "event finished")
				waitTillEventFinished =  GameEvent.CompareEvents(ge, ge.getParameter("event") as IGameEvent);
		}

		private IGameEvent ge;
		public void Tick()
		{
			ge = (node.Content as IGameEvent).Clone() as IGameEvent;
			if(!launched){
				foreach(var param in ge.Params)
					if(ge.getParameter(param) is string)
						ge.setParameter(param, SequenceFormula.ParseFormulas(ge.getParameter(param) as string));

				Game.main.enqueueEvent(ge);
				if(ge.getParameter("synchronous")!=null && (bool)ge.getParameter("synchronous") == true)
					waitTillEventFinished = true;
				launched = true;
			}
			if(!waitTillEventFinished)
				finished = true;
		}

		public ISequenceInterpreter Clone(){
			return new GameEventInterpreter();
		}
	}
}