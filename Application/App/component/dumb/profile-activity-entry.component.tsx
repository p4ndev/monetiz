import { MaterialIcons } from '@expo/vector-icons';
import { Text, View } from 'react-native';

import { HelperStyle, ProfileActivityStyle } from "../../provider/styles";
import { ActivityService } from '../../provider/services';

import { ActivityEntryInterface } from "../../shared/interfaces";

export default function ProfileActivityEntry({ source } : { source : ActivityEntryInterface }){
    const {
        textColor, stageBackgroundColor, iconBackgroundColor,
        iconName, name, summary,
        leftTranslatedContent, leftContent,
        centerTranslatedContent, centerContent,
        createdAt, eligible, id
    } = ActivityService.ParseActivityEntry(source);

    if(eligible === true)
        return (
            <View style={[ProfileActivityStyle.stage, stageBackgroundColor]} id={'pnActivityEntry-' + id}>
                <View style={ProfileActivityStyle.header}>
                    <View style={ProfileActivityStyle.headerLeft}>
                        <Text style={[HelperStyle.bold, ProfileActivityStyle.headline, textColor]} id={'txtTitle-' + id}>
                            { name }
                        </Text>
                        <Text style={[ProfileActivityStyle.label, HelperStyle.opaque]} id={'txtContent-' + id}>
                            { summary }
                        </Text>
                    </View>
                    <View style={ProfileActivityStyle.headerRight}>
                        <View style={[ProfileActivityStyle.iconStage, iconBackgroundColor]}>
                            {
                                ActivityService.RenderImage(source.icon.toString())
                                ?
                                    <MaterialIcons name={iconName} size={25} color={"#FFF"} />
                                :                                
                                    <Text style={[HelperStyle.bold, ProfileActivityStyle.iconLabel]} id={'lblIcon-' + id}>{source.icon}</Text>
                            }
                        </View>
                    </View>
                </View>
                <View style={ProfileActivityStyle.footer}>                
                    <View style={ProfileActivityStyle.row} id={'txtLeftContent-' + id}>
                    {
                        source.leftContent &&
                            <Text style={[ProfileActivityStyle.label]}>
                                <Text style={HelperStyle.opaque}>{ leftTranslatedContent } </Text>
                                <Text style={[HelperStyle.bold, ProfileActivityStyle.answer, textColor]}>
                                    { leftContent }
                                </Text>
                            </Text>
                    }
                    </View>
                    <View style={ProfileActivityStyle.row} id={'txtCenterContent-' + id}>
                    {
                        source.centerContent &&
                            <Text style={[ProfileActivityStyle.label]}>
                                <Text style={HelperStyle.opaque}>{ centerTranslatedContent } </Text>
                                <Text style={[HelperStyle.bold, ProfileActivityStyle.answer, textColor]}>
                                    { centerContent }
                                </Text>
                            </Text>
                    }
                    </View>
                    <View id={'txtRightContent-' + id}>
                        <Text style={[ProfileActivityStyle.label, HelperStyle.opaque]}>
                            { createdAt }
                        </Text>
                    </View>
                </View>
            </View>
        );
}