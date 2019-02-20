using AntonioHR.AnimationHelpers.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace AntonioHR.AnimationHelpers
{
    [RequireComponent(typeof(Animator))]
    public class AnimationQueuePlayable : MonoBehaviour
    {
        [SerializeField]
        private AnimationClip[] clips;


        private PlayableGraph playableGraph;
        private PlayQueuePlayable playQueue;

        private void Start()
        {
            playableGraph = PlayableGraph.Create();

            var playQueuePlayable = ScriptPlayable<PlayQueuePlayable>.Create(playableGraph);
            playQueue = playQueuePlayable.GetBehaviour();
            playQueue.Initialize(clips, playQueuePlayable, playableGraph, OnNewClip);

            var playableOutput = AnimationPlayableOutput.Create(playableGraph, "Animation", GetComponent<Animator>());

            playableOutput.SetSourcePlayable(playQueuePlayable);
            playableOutput.SetSourceOutputPort(0);

            playableGraph.Play();
        }

        private void OnDestroy()
        {
            playableGraph.Destroy();
        }

        private void OnNewClip()
        {
            Debug.Log("New Clip!");
        }
    }
}
