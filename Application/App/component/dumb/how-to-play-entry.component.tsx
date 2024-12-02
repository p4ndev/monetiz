import { Pressable, View, Text } from "react-native";

import { HelperStyle, HowToPlayEntryStyle } from "../../provider/styles";
import { HowToPlayEntryInterface } from "../../shared/interfaces";
import { useStyleOrNull } from "../../provider/handlers";

export default function HowToPlayEntry(props : HowToPlayEntryInterface){
  const { id, opened, question, answer } = props.source;
  const stageStyle = [HowToPlayEntryStyle.stage, useStyleOrNull(opened, HowToPlayEntryStyle.activeStage)];
  const buttonStyle = [HowToPlayEntryStyle.link, HelperStyle.semiBold, useStyleOrNull(opened, HowToPlayEntryStyle.activeLink)];

  return (
    <View style={stageStyle}>
      <Pressable onPress={() => props.onClick(id)}>
        <Text style={buttonStyle}>
          { question }
        </Text>
      </Pressable>
      {
        opened === true &&
          <Text style={HowToPlayEntryStyle.activeContent}>
            { answer }
          </Text>
      }
    </View>
  );    
}