﻿namespace Codecool.MarsExploration.MapGenerator.Configuration.Model;

public record MapConfiguration(
    int MapSize,
    double ElementToSpaceRatio,
    IEnumerable<MapElementConfiguration> MapElementConfigurations);
