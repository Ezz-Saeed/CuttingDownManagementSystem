// models/network-element.model.ts
export interface INetworkElement {
  networkElementKey: number;
  networkElementName: string;
  networkElementType: string;
  parentKey?: number;
  children?: INetworkElement[];
  expanded?: boolean;
  checked?: boolean;
}
