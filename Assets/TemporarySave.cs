for (int i = 2; i < 6 ; i++)
            {
                if (_g.modifiers[i] = StatBooster.HPflat || _g.modifiers[i] = StatBooster.ATTACKFLAT || _g.modifiers[i] = StatBooster.DEFFLAT || _g.modifiers[i] = StatBooster.MAJFLAT || _g.modifiers[i] = StatBooster.MAJDEFFLAT || _g.modifiers[i] = StatBooster.SPEED){
                    switch (_g.modifiers[i])
                    {
                        case StatBooster.HPFLAT:
                            calculateOtherflat[0] = calculateOtherflat[0] + _g.modifiers[i];
                            break;
                        case StatBooster.ATTACKFLAT:
                            calculateOtherflat[1] = calculateOtherflat[0] + _g.modifiers[1];
                            break;
                        case StatBooster.DEFFLAT:

                            break;
                        case StatBooster.MAJFLAT:

                            break;
                        case StatBooster.MAJDEFFLAT:

                            break;
                        case StatBooster.HPPERCENT:
                            calculatePercent[0] = calculatePercent[0] + _g.modifiers[i]
                            break;
                        case StatBooster.ATTACKPERCENT:

                            break;
                        case StatBooster.DEFPERCENT:

                            break;
                        case StatBooster.MAJPERCENT:

                            break;
                        case StatBooster.MAJDEFPERCENT:

                            break;
                        case StatBooster.SPEED:

                            break:
                        case StatBooster.ACC:

                            break;
                        case StatBooster.RES:

                            break;
                        default:
                        break;
                    }
                }
            }