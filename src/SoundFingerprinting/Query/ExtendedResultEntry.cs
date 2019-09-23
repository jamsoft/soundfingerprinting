﻿
namespace SoundFingerprinting.Query
{
    using System;
    using System.Linq;

    using SoundFingerprinting.DAO.Data;
    using SoundFingerprinting.LCS;

    public class ExtendedResultEntry : ResultEntry
    {
        public ExtendedResultEntry(TrackData track, Coverage coverage, double confidence, double score, DateTime matchedAt)
            : base(track, 
                coverage.QueryMatchStartsAt,
                coverage.QueryCoverageSeconds,
                coverage.MatchLengthWithTrackDiscontinuities,
                coverage.TrackMatchStartsAt,
                coverage.TrackStartsAt,
                confidence, 
                score, 
                coverage.QueryLength, 
                matchedAt)
        {
            ResultCoverage = coverage;
        }

        public Coverage ResultCoverage { get; }

        public bool StrongMatch
        {
            get
            {
                return EstimatedCoverage > 0.9 && !ResultCoverage.TrackDiscontinuities.Any()
                                               && !ResultCoverage.QueryDiscontinuities.Any();
            }
        }
    }
}