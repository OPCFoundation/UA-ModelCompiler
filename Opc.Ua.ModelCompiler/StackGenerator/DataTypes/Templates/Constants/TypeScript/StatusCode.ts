export enum StatusCodes {}
// ***START***
interface IUtilsStatusCodeObject {
   code: number
}

export class StatusUtils {
   public static toCode(value: number | IUtilsStatusCodeObject | undefined): number {
      if (!value) return 0;
      let code: number | undefined
      switch (typeof value) {
         case 'number':
            code = value
            break;
         case 'object':
            code = value["code"]
            break;
         default:
            code = undefined
            break;
      }
      return code ?? 0;
   }
   public static toHex(code: number): string {
      let text: string = code.toString(16).toUpperCase();
      while (text.length < 8) {
         text = '0' + text;
      }
      return '0x' + text;
   }
   public static isGood(value: number | IUtilsStatusCodeObject | undefined): boolean {
      return (StatusUtils.toCode(value) & 0xD0000000) === 0;
   }
   public static isUncertain(value: number | IUtilsStatusCodeObject | undefined): boolean {
      return (StatusUtils.toCode(value) & 0x40000000) !== 0;
   }
   public static isBad(value: number | IUtilsStatusCodeObject | undefined): boolean {
      return (StatusUtils.toCode(value) & 0x80000000) !== 0;
   }
   public static codeBits(value: number | IUtilsStatusCodeObject | undefined): number {
      return (StatusUtils.toCode(value) ?? 0 & 0xFFFF0000);
   }
   public static infoBits(value: number | IUtilsStatusCodeObject | undefined): number {
      return (StatusUtils.toCode(value) ?? 0 & 0x0000FFFF);
   }
   public static toText(value: number | IUtilsStatusCodeObject | undefined): string {
      const code = StatusUtils.toCode(value);
      return Object.keys(StatusCodes).find((key: string) => StatusCodes[key as keyof typeof StatusCodes] === code) ?? StatusUtils.toHex(code);
   }
}
// ***END***