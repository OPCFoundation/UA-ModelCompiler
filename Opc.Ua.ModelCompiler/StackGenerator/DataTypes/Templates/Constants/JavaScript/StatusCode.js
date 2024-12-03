// ***START***
export class StatusUtils {
   static toCode(value) {
      if (!value) return 0;
      let code = typeof value === 'number' ? value : undefined;
      if (code === undefined) {
         const field = value["code"];
         code = typeof field === 'number' ? field : undefined;
      }
      return code ?? 0;
   }
   static toHex(code) {
      let text = code.toString(16).toUpperCase();
      while (text.length < 8) {
         text = '0' + text;
      }
      return '0x' + text;
   }
   static isGood(value) {
      return (StatusUtils.toCode(value) & 0xD0000000) === 0;
   }
   static isUncertain(value) {
      return (StatusUtils.toCode(value) & 0x40000000) !== 0;
   }
   static isBad(value) {
      return (StatusUtils.toCode(value) & 0x80000000) !== 0;
   }
   static codeBits(value) {
      return (StatusUtils.toCode(value) ?? 0 & 0xFFFF0000);
   }
   static infoBits(value) {
      return (StatusUtils.toCode(value) ?? 0 & 0x0000FFFF);
   }
   static toText(value) {
      const code = StatusUtils.toCode(value);
      return Object.keys(StatusCodes).find(key => StatusCodes[key] === code) ?? StatusUtils.toHex(code);
   }
}
// ***END***